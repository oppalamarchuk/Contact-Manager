using ContactManager.BLL.IServices;
using ContactManager.BLL.Services;
using ContactManager.DAL;
using ContactManager.DAL.IRepositories;
using ContactManager.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ContactManager;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews(); 
        builder.Services.AddDbContext<ManagerDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddTransient<ICsvService, CsvService>();
        builder.Services.AddTransient<IEmployeeService, EmployeeService>();
        
       
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
    }
}