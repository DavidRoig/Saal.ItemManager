using Saal.ItemManager.Core.Repositories;
using Saal.ItemManager.Core.Services;
using Saal.ItemManager.Infrastructure.Repositories;

namespace Saal.ItemManager.Api
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
        }

        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemJsonRepository>();
        }
    }
}
