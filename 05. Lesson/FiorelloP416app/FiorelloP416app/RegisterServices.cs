using FiorelloP416.DAL;
using Microsoft.EntityFrameworkCore;

namespace FiorelloP416
{
    public static class RegisterServices
    {
        public static void Register(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(1);
            });
        }
    }
}