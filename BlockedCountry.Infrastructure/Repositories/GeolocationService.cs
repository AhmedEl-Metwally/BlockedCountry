using BlockedCountry.Domain.DTOS;
using BlockedCountry.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace BlockedCountry.Infrastructure.Repositories
{
    public class GeolocationService(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : IGeolocationService
    {
        public async Task<GeolocationDTO> GetCountryDetailsAsync(string ipAddress)
        {
            var client = _httpClientFactory.CreateClient();
            var baseUrl = _configuration["GeolocationApi:BaseUrl"]?.TrimEnd('/') + "/";
            var url = $"{baseUrl}{ipAddress}/json/";

            try
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return new GeolocationDTO(null, null, null);
                
                var result = await response.Content.ReadFromJsonAsync<GeolocationDTO>();

                if (result is not null && !string.IsNullOrEmpty(result.CountryCode))
                    return result with { CountryCode = result.CountryCode.ToUpper() };

                return new GeolocationDTO (null, null, null);
            }
            catch (Exception)
            {
                return new GeolocationDTO(null, null, null);
            }
        }

    }
}
