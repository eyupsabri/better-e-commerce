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
                CategoryId = 1,
                CategoryName = "Elektronik",
            },
            new Category()
            {
                CategoryId = 2,
                CategoryName = "Tuvalet Kağıdı",
            },
            new Category()
            {
                CategoryId = 3,
                CategoryName = "Gazete"
            },
            new Category()
            {
                CategoryId = 4,
                CategoryName = "Telefon"
            });

            List<Product> products = new List<Product>();
            for (int i = 1; i <= 200; i++)
            {
                if (i <= 50)
                {
                    products.Add(new Product()
                    {
                        ProductId = i,
                        ProductName = "Samsung-s20",
                        ProductPrice = 10550.6,
                        ProductDescription = "Cok ucuz",
                        CategoryId = 4,
                    });
                }
                else if (50 < i && i <= 100)
                {
                    products.Add(new Product()
                    {
                        ProductId = i,
                        ProductName = "Hoparlor",
                        ProductPrice = 500,
                        ProductDescription = "Cok ucuz",
                        CategoryId = 1,
                    });
                }
                else if (100 < i && i <= 150)
                {
                    products.Add(new Product()
                    {
                        ProductId = i,
                        ProductName = "Selpak",
                        ProductPrice = 100,
                        ProductDescription = "Cok ucuz",
                        CategoryId = 2,

                    });
                }
                else if (150 < i && i <= 200)
                {
                    products.Add(new Product()
                    {
                        ProductId = i,
                        ProductName = "Sozcu",
                        ProductPrice = 2,
                        ProductDescription = "Cok ucuz",
                        CategoryId = 3,

                    });
                }
            }

            foreach(Product product in products)
            {
                modelBuilder.Entity<Product>().HasData(product);
            }
            
        }
    }
}