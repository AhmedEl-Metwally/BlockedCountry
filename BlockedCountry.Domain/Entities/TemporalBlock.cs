namespace BlockedCountry.Domain.Entities
{
    public class TemporalBlock
    {
        public string CountryCode { get; set; } = string.Empty;
        public DateTime ExpirationTime { get; set; }
        public bool IsExpired => DateTime.UtcNow >= ExpirationTime;
    }
}
