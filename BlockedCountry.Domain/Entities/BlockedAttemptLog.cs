namespace BlockedCountry.Domain.Entities
{
    public class BlockedAttemptLog
    {
        public string IpAddress { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public bool IsBlocked { get; set; }
        public string UserAgent { get; set; } = string.Empty;
        public DateTime TimeStamped { get; set; } = DateTime.UtcNow;
    }
}
