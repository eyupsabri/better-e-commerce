using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().ToTable("Customers");

            modelBuilder.Entity<Category>().ToTable("Categories");

            modelBuilder.Entity<Product>().ToTable("Products");

            modelBuilder.Entity<Order>().ToTable("Orders");

            modelBuilder.Entity<OrderItem>().ToTable("OrderItems");

            //modelBuilder.Entity<Customer>().HasData(new Customer()
            //{
            //    CustomerId = 1,
            //    CustomerName = "Cemre",
            //    Email = "husnu.cemre@gmail.com",
            //    Province = "Manisa",
            //    City = "Alasehir",
            //    StreetAddress = "Yenice mah Sumer Oral cad no 23",
            //    PhoneNumber = "5344181168"

            //}, new Customer()
            //{
            //    CustomerId = 2,
            //    CustomerName = "Husnu",
            //    Email = "husnu.cemre@gmail.com",
            //    Province = "Manisa",
            //    City = "Alasehir",
            //    StreetAddress = "Yenice mah Sumer Oral cad no 23",
            //    PhoneNumber = "5344181168"

            //});

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                IsDeleted = false,
                CategoryId = 1,
                CategoryName = "Elektronik",
                ImageGuid = Guid.NewGuid(),
            },
            new Category()
            {
                IsDeleted = false,
                CategoryId = 2,
                CategoryName = "Tuvalet Kağıdı",
                ImageGuid = Guid.NewGuid(),
            },
            new Category()
            {
                IsDeleted = false,
                CategoryId = 3,
                CategoryName = "Gazete",
                ImageGuid = Guid.NewGuid(),
            },
            new Category()
            {
                IsDeleted = false,
                CategoryId = 4,
                CategoryName = "Telefon",
                ImageGuid = Guid.NewGuid(),
            });

            List<Product> products = new List<Product>();
            for (int i = 1; i <= 52; i++)
            {
                Guid guid = Guid.NewGuid();
                if (i <= 13)
                {                  
                    products.Add(new Product()
                    {
                        ImageGuid = guid,
                        IsDeleted = false,
                        ProductId = i,
                        ProductName = "Samsung-s20",
                        ProductPrice = 10550.6,
                        ProductDescription = "Cok ucuz",
                        CategoryId = 4,
                    });
                    //Burayı degistirmen gerek
                    //File.Copy(@"G:\asplearning\better-clone\e-commerce-asp\assets\products\Samsung-s20.jpg", @"G:\asplearning\better-clone\e-commerce-asp\assets\products\" + guid + ".jpg");
                }
                else if (13 < i && i <= 26)
                {
                    products.Add(new Product()
                    {
                        ImageGuid = guid,
                        IsDeleted = false,
                        ProductId = i,
                        ProductName = "Hoparlor",
                        ProductPrice = 500,
                        ProductDescription = "Cok ucuz",
                        CategoryId = 1,
                    });
                    //File.Copy(@"G:\asplearning\better-clone\e-commerce-asp\assets\products\Hoparlor.jpg", @"G:\asplearning\better-clone\e-commerce-asp\assets\products\" + guid + ".jpg");
                }
                else if (26 < i && i <= 39)
                {
                    products.Add(new Product()
                    {
                        ImageGuid = guid,
                        IsDeleted = false,
                        ProductId = i,
                        ProductName = "Selpak",
                        ProductPrice = 100,
                        ProductDescription = "Cok ucuz",
                        CategoryId = 2,

                    });
                    //File.Copy(@"G:\asplearning\better-clone\e-commerce-asp\assets\products\Selpak.jpg", @"G:\asplearning\better-clone\e-commerce-asp\assets\products\" + guid + ".jpg");
                }
                else if (39 < i && i <= 52)
                {
                    products.Add(new Product()
                    {
                        ImageGuid = guid,
                        IsDeleted = false,
                        ProductId = i,
                        ProductName = "Sozcu",
                        ProductPrice = 2,
                        ProductDescription = "Cok ucuz",
                        CategoryId = 3,

                    });
                    //File.Copy(@"G:\asplearning\better-clone\e-commerce-asp\assets\products\Sozcu.jpg", @"G:\asplearning\better-clone\e-commerce-asp\assets\products\" + guid + ".jpg");
                }
            }

            foreach(Product product in products)
            {
                modelBuilder.Entity<Product>().HasData(product);
                //File.Copy(@"G:\asplearning\better-clone\e-commerce-asp\assets\products\" + product.ProductName + ".jpg", @"G:\asplearning\better-clone\e-commerce-asp\assets\products\" + product.ImageGuid + ".jpg");
            }
            
        }
    }
}