using Microsoft.Extensions.DependencyInjection;
using PlayBall.GroupManagment.Services.Imp.Services;
using PlayBall.GroupManagment.Services.Services;

namespace PlayBall.GroupManagment.Web.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddSingleton<IGroupServices, GroupServices>();

            return services;
        }
    }
}
