using Microsoft.EntityFrameworkCore;
using PracticeP416.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var config = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //options.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
    options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=home}/{action=index}/{id?}"
    );

app.Run();
