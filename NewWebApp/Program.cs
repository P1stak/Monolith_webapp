using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<NewsRepository>();

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

app.UseAuthentication();    // ����������� ��������������

app.UseAuthorization();

//app.MapGet("/", (ApplicationContext db) => db.News.ToList());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}",
	(ApplicationContext db) => db.News.ToList()
	);

app.Run();
