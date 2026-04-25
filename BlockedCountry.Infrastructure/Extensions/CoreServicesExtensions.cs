using BlockedCountry.Domain.Interfaces;
using BlockedCountry.Infrastructure.BackgroundServices;
using BlockedCountry.Infrastructure.Persistence;
using BlockedCountry.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlockedCountry.Infrastructure.Extensions
{
    public static class CoreServicesExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection Services)
        {
            Services.AddSingleton<InMemoryStorage>();

            Services.AddScoped<ICountryRepository, CountryRepository>();
            Services.AddScoped<ILogRepository, LogRepository>();
            Services.AddScoped<IGeolocationService, GeolocationService>();

            Services.AddHostedService<TemporalBlockCleanupService>();

            Services.AddHttpClient();

            Services.AddValidatorsFromAssembly(Assembly.Load("BlockedCountry.Application"));

            return Services;
        }
    }
}
