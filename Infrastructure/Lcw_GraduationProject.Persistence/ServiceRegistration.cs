using Lcw_GraduationProject.Application.Repositories.Customers;
using Lcw_GraduationProject.Application.Repositories.Orders;
using Lcw_GraduationProject.Application.Repositories.Products;
using Lcw_GraduationProject.Persistence.Contexts;
using Lcw_GraduationProject.Persistence.Repositories.Customers;
using Lcw_GraduationProject.Persistence.Repositories.Orders;
using Lcw_GraduationProject.Persistence.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lcw_GraduationProject.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services) //Reference vermeden extension metotlar ile register ederek iletişim kuruyoruz
        {
            services.AddDbContext<LcwAPIDbContext>(options => options.UseNpgsql(Configurations.ConnectionString),ServiceLifetime.Singleton);
            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository,OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository,OrderWriteRepository>();
            services.AddScoped<IProductReadRepository,ProductReadRepository>();
            services.AddScoped<IProductWriteRepository,ProductWriteRepository>();
        }
    }
}
