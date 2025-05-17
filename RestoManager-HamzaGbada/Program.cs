using Microsoft.EntityFrameworkCore;
using RestoManager_HamzaGbada.Models.RestosModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Ajouter Le context à l'injection de dependence de la classe REstoDbContext
builder.Services.AddDbContext<RestosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestoConnection")));
var app = builder.Build();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Proprietaires}/{action=Index}/{id?}");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
