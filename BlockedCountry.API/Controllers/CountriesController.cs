using BlockedCountry.Application.DTOS;
using BlockedCountry.Domain.Entities;
using BlockedCountry.Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BlockedCountry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController(ICountryRepository _countryRepository, IValidator<BlacklistedCountry> _addValidator, IValidator<TemporalBlockDTO> _temporalValidator) : ControllerBase
    {
        //  Add Blocked Country
        [HttpPost("block")]
        public IActionResult AddBlockedCountry([FromBody] BlacklistedCountry country)
        {
            var validation = _addValidator.Validate(country);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);
            country.CountryCode = country.CountryCode.ToUpper();
            var result = _countryRepository.AddBlockedCountry(country);
            if(!result)
                return Conflict("Country is already in the blacklist.");

            return Ok(new { Message = $"{country.CountryCode}Country added to blacklist successfully." });
        }

        // Get All Blocked Countries
        [HttpGet("blocked")]
        public IActionResult GetBlockedCountries([FromQuery] string? search, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var countries = _countryRepository.GetBlockedCountries();
            if (!string.IsNullOrEmpty(search))
            {
                countries = countries.Where(C =>
                    C.CountryCode.Contains(search,StringComparison.OrdinalIgnoreCase) ||
                    C.NameOfCountry.Contains(search,StringComparison.OrdinalIgnoreCase)
                );
            }

            var total = countries.Count();
            var pagedCountries = countries.Skip((page - 1) * pageSize).Take(pageSize);

            return Ok(new { Total = total, Page = page, PageSize = pageSize, Countries = pagedCountries });

        }

        // Delete Blocked Country
        [HttpDelete("block/{countryCode}")]
        public IActionResult RemoveBlockedCountry(string countryCode)
        {
            var removed = _countryRepository.RemoveBlockedCountry(countryCode);
            if(!removed)
                return NotFound("Country not found in blocked list.");

            return Ok(new { Message = $"{countryCode} removed from blacklist successfully." });
        }

        //Temporal Block
        [HttpPost("temporal-block")]
        public IActionResult TemporalBlock([FromBody] TemporalBlockDTO temporalBlock)
        {
            var validation = _temporalValidator.Validate(temporalBlock);
            if(!validation.IsValid)
                return BadRequest(validation.Errors);

            var temporal = new TemporalBlock
            {
                CountryCode = temporalBlock.CountryCode,
                ExpirationTime = DateTime.UtcNow.AddMinutes(temporalBlock.DurationMinutes)
            };

            var added = _countryRepository.AddTemporalBlock(temporal);
            if(!added)
                return Conflict("Country is already blocked or has an active temporal block.");

            return Ok(new { Message = $"{temporalBlock.CountryCode} blocked for {temporalBlock.DurationMinutes} minutes." });
        }
    }
}
