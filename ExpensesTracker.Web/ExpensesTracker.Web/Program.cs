using ExpensesTracker.Web.Data;

using Microsoft.EntityFrameworkCore;

namespace ExpensesTracker.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("ExpensesTrackerConnection")
                                   ?? throw new InvalidOperationException("Connection string 'ExpensesTrackerConnection' not found.");

            builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseMySQL(connectionString)
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
