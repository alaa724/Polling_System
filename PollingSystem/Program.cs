using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Polling.DataAccessLayer.Data;
using Polling.DataAccessLayer.Models;
using PollingSystem.Extensions;
using PollingSystem.Helpers;

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

            webApplicationBuilder.Services.ApplicationServices(); // Extention Method

            webApplicationBuilder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));

            webApplicationBuilder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true; // @#$
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;

                //options.User.AllowedUserNameCharacters = "asdfg12345@"
                options.User.RequireUniqueEmail = true;

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(5);


            })
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            webApplicationBuilder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/SignIn";
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.AccessDeniedPath = "/Home/Error";

            });


            webApplicationBuilder.Services.AddAuthentication(options =>
            {

            })
                .AddCookie("Polling", options =>
                {
                    options.LoginPath = "Account/SignIn";
                    options.ExpireTimeSpan = TimeSpan.FromDays(1);
                    options.AccessDeniedPath = "/Home/Error";

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
