using Hotellerie_Hamza.Models.HotellerieModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Register DbContext and configure the connection string from appsettings.json
builder.Services.AddDbContext<HotellerieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotellerieConnection"))
);
var app = builder.Build();


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

// Set the default route to the Index action of HotelsController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hotels}/{action=Index}/{id?}");
app.Run();
