using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Polling.DataAccessLayer.Data;

namespace PollingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Configur Services
            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            webApplicationBuilder.Services.AddControllersWithViews(); // Register Built-In webApplicationBuilder.Services Required by MVC

            webApplicationBuilder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                object value = options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection"));
            });



            #endregion


            var app = webApplicationBuilder.Build();

            #region Configure Kestrel MiddleWare

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            #endregion

            app.Run();
        }
    }
}
