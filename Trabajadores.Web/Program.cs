using Trabajadores.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<WorkerApiService>(c =>
{
    c.BaseAddress = new Uri("http://api:8080/");
});
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 👉 Ruta MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Workers}/{action=Index}/{id?}");

app.Run();
