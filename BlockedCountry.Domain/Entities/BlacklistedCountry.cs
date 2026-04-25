namespace BlockedCountry.Domain.Entities
{
    public class BlacklistedCountry
    {
        public string CountryCode { get; set; } = string.Empty;
        public string NameOfCountry { get; set; } = string.Empty;
        public DateTime BlockedAt { get; set; } = DateTime.UtcNow;
    }
}
