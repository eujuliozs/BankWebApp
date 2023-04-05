using BankWebApp.DataObjects;
using BankWebApp.Models.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace BankWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<bankdataContext>(options => options.UseMySql("server=localhost;port=3306;user=root;password=10032005Jc%;database=bankdata", ServerVersion.Parse("8.0.30-mysql"))
                );
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<AccountService>();

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
}