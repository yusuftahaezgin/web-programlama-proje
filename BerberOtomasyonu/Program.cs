using BerberOtomasyonu.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Veriler>(options=>{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("database");
    options.UseSqlite(connectionString);
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/HesapIslemleri/Login"; // kullanici giris yapmazsa yonlenecegi sayfa
        options.AccessDeniedPath = "/Home/ErisimHatasi"; // kullanici rolu eksikse yonlenecegi sayfa
    });


builder.Services.AddAuthorization();

var app = builder.Build();
VeriDoldur.TestVerileriniDoldur(app);



app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
