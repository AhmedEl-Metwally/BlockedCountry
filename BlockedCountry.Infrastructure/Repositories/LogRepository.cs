using BlockedCountry.Domain.Entities;
using BlockedCountry.Domain.Interfaces;
using BlockedCountry.Infrastructure.Persistence;

namespace BlockedCountry.Infrastructure.Repositories
{
    public class LogRepository(InMemoryStorage _storage) : ILogRepository
    {
        public void LogAttempt(BlockedAttemptLog log)
            => _storage.BlockedAttemptLogs.Add(log);

        public IEnumerable<BlockedAttemptLog> GetLogs()
            => _storage.BlockedAttemptLogs.OrderByDescending(L => L.TimeStamped);   
    }
}
