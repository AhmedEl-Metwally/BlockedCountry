using BlockedCountry.Domain.Entities;

namespace BlockedCountry.Domain.Interfaces
{
    public interface ILogRepository
    {
        void LogAttempt(BlockedAttemptLog log);
        IEnumerable<BlockedAttemptLog> GetLogs();
    }
}
