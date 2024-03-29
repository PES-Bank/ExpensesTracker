using ExpensesTracker.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Internal;
using ExpensesTracker.Core.Services.Expenses;
using ExpensesTracker.Data.Repositories;
using ExpensesTracker.Web.Data.Entities;
using System.Reflection;

namespace ExpensesTracker.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("ExpensesTrackerConnection")
                        ?? throw new InvalidOperationException("Connection string 'ExpensesTrackerConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthorization();

            RegisterServices(builder);
            RegisterAutoMapper(builder);

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
        private static void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRepository<Expense>, Repository<Expense>>();
            builder.Services.AddScoped<IExpenseService, ExpenseService>();
        }
        private static void RegisterAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
