using Application.Repositories;
using Application.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Repositories.Base;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserDal, UserDal>();
            services.AddScoped<ITicketDal, TicketDal>();
        }
    }
}