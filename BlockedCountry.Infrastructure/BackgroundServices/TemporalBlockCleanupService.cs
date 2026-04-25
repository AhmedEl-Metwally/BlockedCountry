using BlockedCountry.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BlockedCountry.Infrastructure.BackgroundServices
{
    public class TemporalBlockCleanupService(IServiceScopeFactory _serviceScopeFactory, ILogger<TemporalBlockCleanupService> _logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Temporal Block Cleanup Service is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);

                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var countryRepository = scope.ServiceProvider.GetRequiredService<ICountryRepository>();

                        var expiredBlocks = countryRepository.GetActiveTemporalBlocks().Where(T => T.IsExpired).ToList();

                        foreach (var block in expiredBlocks)
                        {
                            countryRepository.RemoveTemporalBlock(block.CountryCode);
                            _logger.LogInformation($"[Cleanup] Auto-unblocked country: {block.CountryCode}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while cleaning up temporal blocks.");
                }
            }

        }
    }
}
