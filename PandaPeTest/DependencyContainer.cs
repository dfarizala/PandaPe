using MediatR;
using Microsoft.EntityFrameworkCore;
using PandaPeTest.Api.Domain.Interfaces;
using PandaPeTest.Api.Infrastructure;
using PandaPeTest.Api.Infrastructure.Repository;
using System.Reflection;

namespace PandaPeTest.Api
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPandaPeServices(this IServiceCollection services,
                                                                 IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
                (configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, ApplicationUnitOfWork>();
            services.AddScoped(typeof(IApplicationRepository<>), typeof(ApplicationRepository<>));

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
