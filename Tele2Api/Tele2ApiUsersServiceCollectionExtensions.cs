using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Core.Tele2Api;

namespace Tele2Api
{
    public static class Tele2ApiUsersServiceCollectionExtensions
    {
        public static void AddTele2ApiUsers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITele2ApiUsers, Tele2ApiUsers>();
        }
    }
}
