using FiorelloP416.DAL;
using Microsoft.EntityFrameworkCore;
using System;

namespace FiorelloP416
{
    public static class RegisterServices
    {
        public static void Register(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
        }
    }
}