var builder = WebApplication.CreateBuilder(args);
//builder.Services.addSqlServer();
//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();



var app = builder.Build();

//app.MapGet("/", () => "Hello World!"); localhost/user/test
//app.MapControllerRoute(
//    name: "default",
//    pattern:"{controller}/{action}/{id}"
//    );

app.MapControllerRoute(
    "default",
    "{controller=home}/{action=index}/{id?}");
app.UseStaticFiles();


app.Run();
