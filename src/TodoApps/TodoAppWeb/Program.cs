using Microsoft.EntityFrameworkCore;
using TodoAppLibs;
using TodoAppLibs.Repositories;
using TodoAppWeb.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddLogging(x => {
    x.AddConfiguration(builder.Configuration.GetSection("Logging"));
    x.AddLog4Net();
});
var dbType = builder.Configuration.GetValue<DbType>("DBSettings:Type");
builder.Services.AddDbContext<AppDbContext>(option => {
    // PostgreSQL
    if (dbType == DbType.PostgreSQL)
    {
        option.UseNpgsql(builder.Configuration.GetConnectionString("ConnStr"));
    }
    // Šù’è‚ÌDB‚ÍSQLServer
    else
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"));
    }
    option.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<ITodo, Todo>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

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
