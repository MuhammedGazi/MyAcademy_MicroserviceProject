using ECommerce.Discount.DataAccess.Context;
using ECommerce.Discount.DataAccess.Repositories.CouponsRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Discount.DataAccess.Extensions
{
    public static class DataAccessRegistrations
    {
        public static void AddDataAccess(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ICouponsRepository,CouponsRepository>();
        }
    }
}
