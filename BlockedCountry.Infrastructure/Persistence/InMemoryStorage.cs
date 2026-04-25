using BlockedCountry.Domain.Entities;
using System.Collections.Concurrent;

namespace BlockedCountry.Infrastructure.Persistence
{
    public class InMemoryStorage
    {
        public ConcurrentDictionary<string, BlacklistedCountry> BlockedCountries { get; } = new();
        public ConcurrentDictionary<string, TemporalBlock> TemporalBlocks { get; } = new();
        public ConcurrentBag<BlockedAttemptLog> BlockedAttemptLogs { get; } = [];
    }
}
