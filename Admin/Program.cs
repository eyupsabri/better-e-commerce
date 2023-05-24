using Business;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repos;

namespace Customer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            builder.Services.AddScoped<ICategoriesService, CategoriesService>();

            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
            builder.Services.AddScoped<IProductsService, ProductsService>();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1000);
                //options.Cookie.HttpOnly = true;
                //options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.MapControllers();

            app.Run();
        }
    }
}