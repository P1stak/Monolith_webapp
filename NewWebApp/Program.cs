using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NewWebApp;
using NewWebApp.Models;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");



// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<NewsRepository>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
    var rolesManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await RoleInitializer.InitializeAsync(userManager, rolesManager);
}

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

app.UseAuthentication();    // подключение аутентификации

app.UseAuthorization();

//app.MapGet("/", (ApplicationContext db) => db.News.ToList());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}",
	(ApplicationContext db) => db.News.ToList()
	);

app.Run();
