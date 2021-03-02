namespace SympliSEOTracker.Service.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupServices(this IServiceCollection services)
        {
            services.AddTransient<ISearchResultUpdater, SearchResultUpdater>();

            return services;
        }
    }
}
