using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Extentions;
using CreditManagementSystemHomework.Profiles;
using CreditManagementSystemHomework.Repository.Implementation;
using CreditManagementSystemHomework.Repository.Interfaces;
using CreditManagementSystemHomework.Service.Implementation;
using CreditManagementSystemHomework.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CreditManagementSystemHomework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<CreditManagementDB>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<CreditManagementDB>()
    .AddDefaultTokenProviders();

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

            builder.Services.AddCustomRepositories();
            builder.Services.AddCustomServices();


            builder.Services.AddAutoMapper(typeof(CustomProfile).Assembly);

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
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
