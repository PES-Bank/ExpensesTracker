using ExpensesTracker.Web.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ExpensesTracker.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .Build();

            

            //// Add services to the container.
            //builder.Services.AddControllersWithViews();

            //// Get connection string from appsettings.json
            //var connectionString = configuration.GetConnectionString("ExpensesTrackerConnection")
            //                       ?? throw new InvalidOperationException("Connection string 'ExpensesTrackerConnection' not found.");

            //builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
            //    options.UseMySQL(connectionString)
            //);
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("ExpensesTrackerConnection")
                        ?? throw new InvalidOperationException("Connection string 'ExpensesTrackerConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


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
        private static void RegisterDbContext(WebApplicationBuilder builder)
        {
            // TODO: Read from appsettings.json!
            var connectionString = builder.Configuration.GetValue<string>("Database:ConnectionString");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
#if DEBUG
                options.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
#endif

                options.UseMySQL(connectionString);
            });
        }
    }
}
