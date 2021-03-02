namespace SympliSEOTracker.Repository.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class RepositoryServiceCollectionExtension
    {

        public static IServiceCollection SetupRepositories(this IServiceCollection services)
        {
            services.AddTransient<ISearchResultRepository, InMemorySearchResultRepository>();

            return services;
        }
    }
}
