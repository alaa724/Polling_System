using Microsoft.AspNetCore.Hosting;
using Polling.BusinessLogicLayer.ServicesContract;
using Polling.DataAccessLayer.Interfaces;
using Polling.DataAccessLayer.Repositories;
using Polling.DataAccessLayer;
using Polling.BusinessLogicLayer.Services;
using Questioning.BusinessLogicLayer.ServicesContract;
using Questioning.BusinessLogicLayer.Services;
using Answering.BusinessLogicLayer.ServicesContract;
using Answersing.BusinessLogicLayer.Services;

namespace PollingSystem.Extensions
{
    public static class ApplicationServicesExtention 
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IPollRepository, PollRepositoriey>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IUniteOfWork, UnitOfWork>();

            // Register services
            services.AddScoped<IPollService, PollService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IAnswerService, AnswerService>();

            return services;
        }
    }
}
