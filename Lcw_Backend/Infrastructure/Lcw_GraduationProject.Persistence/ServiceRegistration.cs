using Lcw_GraduationProject.Application.Repositories.Categories;
using Lcw_GraduationProject.Application.Repositories.Offers;
using Lcw_GraduationProject.Application.Repositories.Orders;
using Lcw_GraduationProject.Application.Repositories.Products;
using Lcw_GraduationProject.Application.Repositories.Users;
using Lcw_GraduationProject.Persistence.Contexts;
using Lcw_GraduationProject.Persistence.Repositories.Categories;
using Lcw_GraduationProject.Persistence.Repositories.Offers;
using Lcw_GraduationProject.Persistence.Repositories.Orders;
using Lcw_GraduationProject.Persistence.Repositories.Products;
using Lcw_GraduationProject.Persistence.Repositories.Users;
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
            services.AddScoped<IUserReadRepository,UserReadRepository>();
            services.AddScoped<IUserWriteRepository,UserWriteRepository>();
            services.AddScoped<IOrderReadRepository,OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository,OrderWriteRepository>();
            services.AddScoped<IProductReadRepository,ProductReadRepository>();
            services.AddScoped<IProductWriteRepository,ProductWriteRepository>();   
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IOfferReadRepository, OfferReadRepository>();
            services.AddScoped<IOfferWriteRepository, OfferWriteRepository>();
        }
    }
}
