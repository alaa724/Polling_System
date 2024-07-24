using Microsoft.AspNetCore.Hosting;
using Polling.BusinessLogicLayer;
using Polling.BusinessLogicLayer.Interfaces;

namespace PollingSystem.Extensions
{
    public static class ApplicationServicesExtention 
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IUniteOfWork, UnitOfWork>();
            

            return services;
        }
    }
}
