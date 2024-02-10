using Customer.Application.AppServices;
using Customer.Core.Interfaces.Common;
using Customer.Core.Interfaces.IAppServices;
using Customer.Infrastructure.DBContext;
using Customer.Infrastructure.Repository;

namespace Customer.WebAPI.Startup
{
    public static class DependencyInjectionSetup
    {
     

        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            #region AppServices

            services.AddScoped<ICustomerService, CustomerService>();
            #endregion



            return services;
        }

     
        public static IServiceCollection RegisterAppRepositories(this IServiceCollection services)
        {
            #region App

            services.AddScoped(typeof(IRepository<Customer.Core.DomainModels.Customer, Guid>), typeof(Repository<Customer.Core.DomainModels.Customer, Guid, AppDBContext>));
            #endregion



            return services;
        }
    }
}

