using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartSchooler.Domain.Repositories;
using SmartSchooler.Infrastructure.Persistance;
using SmartSchooler.Infrastructure.Persistance.Repositories;

namespace SmartSchooler.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddDbContextPool<ApplicationDbContext>(builder =>
            {
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            });

            return services;
        }
    }
}
