using DataServices;
using EFCore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.Extensions
{
    public static  class RegisterServices
    {
        public static void RegisterEfDalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EfContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RestaurantCS")));
            services.AddScoped<ICityService, EfDataService>();
            services.AddScoped<IRestaurantService, EfDataService>();
            services.AddScoped<IDataService, EfDataService>();
        }
    }
}