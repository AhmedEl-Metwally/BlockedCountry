using System.Text.Json.Serialization;

namespace BlockedCountry.Domain.DTOS
{
    public record GeolocationDTO(
        [property : JsonPropertyName("country_code")] string? CountryCode,
        [property: JsonPropertyName("country_name")] string? NameOfCountry,
        [property : JsonPropertyName("org")] string? IPS = null
        );

}
