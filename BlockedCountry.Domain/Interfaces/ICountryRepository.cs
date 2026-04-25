using BlockedCountry.Domain.Entities;

namespace BlockedCountry.Domain.Interfaces
{
    public interface ICountryRepository
    {
        bool AddBlockedCountry(BlacklistedCountry country);
        bool RemoveBlockedCountry(string countryCode);
        IEnumerable<BlacklistedCountry> GetBlockedCountries();

        bool AddTemporalBlock(TemporalBlock temporalBlock);
        IEnumerable<TemporalBlock> GetActiveTemporalBlocks();
        void RemoveTemporalBlock(string countryCode);
    }
}
