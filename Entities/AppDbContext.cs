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
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 1,
                ProductName = "Samsung-s20",
                ProductPrice = 10900,
                ProductDescription = "Cok ucuz",
                CategoryId = 4,
            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 2,
                ProductName = "Powerway Wrx01",
                ProductPrice = 500,
                ProductDescription = "Cok ucuz",
                CategoryId = 1,
            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 3,
                ProductName = "Selpak",
                ProductPrice = 100,
                ProductDescription = "Cok ucuz",
                CategoryId = 2,

            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 4,
                ProductName = "Sözcü",
                ProductPrice = 2,
                ProductDescription = "Cok ucuz",
                CategoryId = 3,

            });

            //5-8
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 5,
                ProductName = "Samsung-s21",
                ProductPrice = 14000,
                ProductDescription = "Cok ucuz",
                CategoryId = 4,
            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 6,
                ProductName = "Resolut hoparlör",
                ProductPrice = 145,
                ProductDescription = "Cok ucuz",
                CategoryId = 1,
            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 7,
                ProductName = "Solo",
                ProductPrice = 150,
                ProductDescription = "Cok ucuz",
                CategoryId = 2,

            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 8,
                ProductName = "Milliyet",
                ProductPrice = 5,
                ProductDescription = "Cok ucuz",
                CategoryId = 3,

            });
            //9-12
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 9,
                ProductName = "Samsung-s22",
                ProductPrice = 18000,
                ProductDescription = "Cok ucuz",
                CategoryId = 4,
            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 10,
                ProductName = "Mateo Işıklı Hoparlör",
                ProductPrice = 143,
                ProductDescription = "Cok ucuz",
                CategoryId = 1,
            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 11,
                ProductName = "Papia",
                ProductPrice = 180,
                ProductDescription = "Cok ucuz",
                CategoryId = 2,

            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 12,
                ProductName = "Hürriyet",
                ProductPrice = 3,
                ProductDescription = "Cok ucuz",
                CategoryId = 3,

            });
            //13-16
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 13,
                ProductName = "Samsung-s23",
                ProductPrice = 22000,
                ProductDescription = "Cok ucuz",
                CategoryId = 4,
            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 14,
                ProductName = "Loewe Hoparlor",
                ProductPrice = 432,
                ProductDescription = "Cok ucuz",
                CategoryId = 1,
            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 15,
                ProductName = "Familia",
                ProductPrice = 230,
                ProductDescription = "Cok ucuz",
                CategoryId = 2,

            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 16,
                ProductName = "Posta",
                ProductPrice = 2.5,
                ProductDescription = "Cok ucuz",
                CategoryId = 3,

            });
            //17-20
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 17,
                ProductName = "Iphone X",
                ProductPrice = 10000,
                ProductDescription = "Cok ucuz",
                CategoryId = 4,
            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 18,
                ProductName = "Pib blue x1",
                ProductPrice = 143,
                ProductDescription = "Cok ucuz",
                CategoryId = 1,
            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 19,
                ProductName = "Diversey",
                ProductPrice = 100,
                ProductDescription = "Cok ucuz",
                CategoryId = 2,

            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 20,
                ProductName = "Evrensel",
                ProductPrice = 11,
                ProductDescription = "Cok ucuz",
                CategoryId = 3,

            });
            //21-24
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 21,
                ProductName = "Xiaomi Poco f6",
                ProductPrice = 21000,
                ProductDescription = "Cok ucuz",
                CategoryId = 4,
            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 22,
                ProductName = "Steel Series Rival 3",
                ProductPrice = 750,
                ProductDescription = "Cok ucuz",
                CategoryId = 1,
            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 23,
                ProductName = "Drop Natura",
                ProductPrice = 60,
                ProductDescription = "Cok ucuz",
                CategoryId = 2,

            });
            products.Add(new Product()
            {
                ImageGuid = Guid.NewGuid(),
                IsDeleted = false,
                ProductId = 24,
                ProductName = "Cumhuriyet",
                ProductPrice = 15,
                ProductDescription = "Cok ucuz",
                CategoryId = 3,

            });
            //for (int i = 1; i <= 52; i++)
            //{
            //    Guid guid = Guid.NewGuid();
            //    if (i <= 5)
            //    {
            //        products.Add(new Product()
            //        {
            //            ImageGuid = guid,
            //            IsDeleted = false,
            //            ProductId = i,
            //            ProductName = "Samsung-s20",
            //            ProductPrice = 10550.6,
            //            ProductDescription = "Cok ucuz",
            //            CategoryId = 4,
            //        });
            //        //Burayı degistirmen gerek
            //        //File.Copy(@"G:\asplearning\better-clone\e-commerce-asp\assets\products\Samsung-s20.jpg", @"G:\asplearning\better-clone\e-commerce-asp\assets\products\" + guid + ".jpg");
            //    }
            //    else if (5 < i && i <= 10)
            //    {
            //        products.Add(new Product()
            //        {
            //            ImageGuid = guid,
            //            IsDeleted = false,
            //            ProductId = i,
            //            ProductName = "Hoparlor",
            //            ProductPrice = 500,
            //            ProductDescription = "Cok ucuz",
            //            CategoryId = 1,
            //        });
            //        //File.Copy(@"G:\asplearning\better-clone\e-commerce-asp\assets\products\Hoparlor.jpg", @"G:\asplearning\better-clone\e-commerce-asp\assets\products\" + guid + ".jpg");
            //    }
            //    else if (10 < i && i <= 15)
            //    {
            //        products.Add(new Product()
            //        {
            //            ImageGuid = guid,
            //            IsDeleted = false,
            //            ProductId = i,
            //            ProductName = "Selpak",
            //            ProductPrice = 100,
            //            ProductDescription = "Cok ucuz",
            //            CategoryId = 2,

            //        });
            //        //File.Copy(@"G:\asplearning\better-clone\e-commerce-asp\assets\products\Selpak.jpg", @"G:\asplearning\better-clone\e-commerce-asp\assets\products\" + guid + ".jpg");
            //    }
            //    else if (15 < i && i <= 20)
            //    {
            //        products.Add(new Product()
            //        {
            //            ImageGuid = guid,
            //            IsDeleted = false,
            //            ProductId = i,
            //            ProductName = "Sozcu",
            //            ProductPrice = 2,
            //            ProductDescription = "Cok ucuz",
            //            CategoryId = 3,

            //        });
            //        //File.Copy(@"G:\asplearning\better-clone\e-commerce-asp\assets\products\Sozcu.jpg", @"G:\asplearning\better-clone\e-commerce-asp\assets\products\" + guid + ".jpg");
            //    }
            //}

            foreach (Product product in products)
            {
                modelBuilder.Entity<Product>().HasData(product);
                //File.Copy(@"G:\asplearning\better-clone\e-commerce-asp\assets\products\" + product.ProductName + ".jpg", @"G:\asplearning\better-clone\e-commerce-asp\assets\products\" + product.ImageGuid + ".jpg");
            }

        }
    }
}