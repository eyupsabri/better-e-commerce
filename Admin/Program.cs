using Business;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Repos;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            builder.Services.AddScoped<ICategoriesService, CategoriesService>();

            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
            builder.Services.AddScoped<IProductsService, ProductsService>();

            builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
            builder.Services.AddScoped<ICustomersService, CustomersService>();

            builder.Services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
            builder.Services.AddScoped<IOrderItemsService, OrderItemsService>();

            //builder.Services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromSeconds(1000);
            //    //options.Cookie.HttpOnly = true;
            //    //options.Cookie.IsEssential = true;
            //});

            var app = builder.Build();

            //app.UseStaticFiles();

            

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Regex.Replace(builder.Environment.ContentRootPath, builder.Environment.ApplicationName, "assets")),
                RequestPath = new PathString("/assets")

            });





            app.UseRouting();
            //app.UseSession();
            app.MapControllers();

            app.Run();
        }
}
}