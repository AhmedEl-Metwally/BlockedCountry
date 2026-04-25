using BlockedCountry.Domain.Entities;
using BlockedCountry.Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BlockedCountry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpsController(IGeolocationService _geolocationService, ICountryRepository _countryRepository, ILogRepository _logRepository, IValidator<string> _ipValidator) : ControllerBase
    {
        // Lookup
        [HttpGet("lookup")]
        public async Task<IActionResult> Lookup([FromQuery] string? ipAddress)
        {
            var targetIp = string.IsNullOrEmpty(ipAddress) ? HttpContext.Connection.RemoteIpAddress?.ToString() : ipAddress;
            if (string.IsNullOrEmpty(targetIp) || targetIp == "::1")
                targetIp = "156.202.155.101"; 

            var validation = _ipValidator.Validate(targetIp);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var result = await _geolocationService.GetCountryDetailsAsync(targetIp);
            if(result is null || string.IsNullOrEmpty(result.CountryCode))
                return NotFound("Country details not found.");

            return Ok(result);
        }

        //Check Block
        [HttpGet("check-block")]
        public async Task<IActionResult> CheckBlock()
        {
            var callerIp = HttpContext.Connection.RemoteIpAddress?.ToString();
            if (callerIp == "::1") 
                callerIp = "156.202.155.101";

            var geolocationInfo = await _geolocationService.GetCountryDetailsAsync(callerIp);
            var countryCode = geolocationInfo?.CountryCode?.ToUpper();
            if(string.IsNullOrEmpty(countryCode))
                return StatusCode(502, "External Geolocation Service Error.");

            var isBlocked = _countryRepository.GetBlockedCountries().Any(C => C.CountryCode == countryCode) ||
                _countryRepository.GetActiveTemporalBlocks().Any(C => C.CountryCode == countryCode && !C.IsExpired);

            _logRepository.LogAttempt(new BlockedAttemptLog
            {
                IpAddress = callerIp,
                CountryCode = countryCode,
                IsBlocked = isBlocked,
                TimeStamped = DateTime.UtcNow,
                UserAgent = Request.Headers["User-Agent"].ToString()
            });

            return Ok(new { IsBlocked = isBlocked, CountryCode = countryCode, IpAddress = callerIp });
        }
    }
}
