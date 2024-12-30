using Microsoft.EntityFrameworkCore;
using WebApplication1.Abstract;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositorys;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connStr = builder.Configuration.GetConnectionString("ConnStr");
builder.Services.AddDbContext<KitapDBContext>(x => x.UseSqlServer(connStr));

builder.Services.AddIdentity<Kullanici, Rol>(x => x.SignIn.RequireConfirmedAccount = false)
    .AddRoles<Rol>()
    .AddEntityFrameworkStores<KitapDBContext>();
// Servisleri ekleyin
builder.Services.AddScoped<KitapService>();
builder.Services.AddScoped<YazarService>();
builder.Services.AddScoped<KullaniciService>();
builder.Services.AddScoped<KategoriService>();
builder.Services.AddScoped<YayinEviService>();
builder.Services.AddScoped<Kitap_KategoriService>();

// Repository sýnýflarýný ekleyin
builder.Services.AddScoped<ICRUD<Yazar>, BaseRepository<Yazar>>();
builder.Services.AddScoped<KitapRepository>();
builder.Services.AddScoped<YazarRepository>();
builder.Services.AddScoped<KullaniciRepository>();
builder.Services.AddScoped<KategoriRepository>();
builder.Services.AddScoped<YayinEviRepository>();
builder.Services.AddScoped<Kitap_KategoriRepository>();
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
app.UseAuthentication(); //gUvenlik iCin yetkisi yoksa giremesin

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
