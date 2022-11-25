using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using Week_Project.Data;
using Week_Project.Areas.Identity.Data;

namespace Week_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<Week_ProjectContext>(options =>
             {
                 options.UseSqlServer(builder.Configuration.GetConnectionString("Week_ProjectContextConnection"));
             }

            );

            builder.Services.AddDefaultIdentity<Week_ProjectUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<Week_ProjectContext>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();;

            app.UseAuthorization();
           
            

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();
            app.Run();
        }
    }
}