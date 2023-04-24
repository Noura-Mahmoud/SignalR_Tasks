using Microsoft.EntityFrameworkCore;
using productsHub.Hubs;
using productsHub.Models;

namespace productsHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();

            #region DB
            var connectionString = builder.Configuration.GetConnectionString("myConn");
            builder.Services.AddDbContext<MainDbContext>(op => op.UseSqlServer(connectionString));
            #endregion

            #region SignalR
            builder.Services.AddSignalR();
            #endregion

            #region Cors
            builder.Services.AddCors(opt =>

                opt.AddDefaultPolicy(policy =>
                    policy.WithOrigins("http://127.0.0.1:5265").AllowAnyMethod()
                    .AllowAnyHeader().AllowCredentials()
                )
            );
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();

            //Mapping Hub
            app.MapHub<ProductHub>("myProductsHub");

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}