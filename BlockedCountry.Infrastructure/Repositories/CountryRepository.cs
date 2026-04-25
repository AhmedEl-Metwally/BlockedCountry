using BlockedCountry.Domain.Entities;
using BlockedCountry.Domain.Interfaces;
using BlockedCountry.Infrastructure.Persistence;

namespace BlockedCountry.Infrastructure.Repositories
{
    public class CountryRepository(InMemoryStorage _storage) : ICountryRepository
    {
        public bool AddBlockedCountry(BlacklistedCountry country)
            => _storage.BlockedCountries.TryAdd(country.CountryCode.ToUpper(),country);

        public bool RemoveBlockedCountry(string countryCode)
            => _storage.BlockedCountries.TryRemove(countryCode.ToUpper(), out _);

        public IEnumerable<BlacklistedCountry> GetBlockedCountries()
            => _storage.BlockedCountries.Values;


        public bool AddTemporalBlock(TemporalBlock temporalBlock)
            => _storage.TemporalBlocks.TryAdd(temporalBlock.CountryCode.ToUpper(),temporalBlock);

        public IEnumerable<TemporalBlock> GetActiveTemporalBlocks()
            => _storage.TemporalBlocks.Values;

        public void RemoveTemporalBlock(string countryCode)
            => _storage.TemporalBlocks.TryRemove(countryCode.ToUpper(), out _);
      
    }
}
