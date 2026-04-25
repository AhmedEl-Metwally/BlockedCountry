namespace BlockedCountry.Application.DTOS
{
    public class TemporalBlockDTO
    {
        public string CountryCode { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
    }
}
