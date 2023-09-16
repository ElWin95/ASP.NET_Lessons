using MentorApp.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    "default", "{controller=home}/{action=index}/{id?}"
    );

app.Run();
