using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuelloFlix.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Serviço de conexão com o banco de dados
string conn = builder.Configuration. 
GetConnectionString("QuelloFlixConnection");
var version = ServerVersion.AutoDetect(conn);
builder.Services.AddDbContext<AppDbContext>(
    opt => opt.UseMySql(conn, version)
);


// Serviço de gestão de usúarios
builder.Services.AddIdentity<IdentityUser, IdentityRole>(
    opt => opt.SignIn.RequireConfirmedAccount = false
)
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
