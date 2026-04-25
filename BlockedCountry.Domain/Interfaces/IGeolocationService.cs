using BlockedCountry.Domain.DTOS;

namespace BlockedCountry.Domain.Interfaces
{
    public interface IGeolocationService
    {
        Task<GeolocationDTO> GetCountryDetailsAsync(string ipAddress);
    }
}
