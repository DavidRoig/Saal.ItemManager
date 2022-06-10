using Microsoft.Extensions.DependencyInjection;
using Saal.ItemManager.Core.Services;

namespace Saal.ItemManager.Core
{
    /// <summary>
    /// Dependency Injection mapping is stored in Core project to be used from Testing project, CLI, API, etc...
    /// </summary>
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
        }
    }
}
