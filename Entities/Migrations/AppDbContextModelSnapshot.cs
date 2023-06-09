﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Elektronik",
                            IsDeleted = false
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Tuvalet Kağıdı",
                            IsDeleted = false
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Gazete",
                            IsDeleted = false
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Telefon",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems", (string)null);
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<Guid>("ImageGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 4,
                            ImageGuid = new Guid("3d6b26f8-e72c-4a04-92cb-61e69c7cc049"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Samsung-s20",
                            ProductPrice = 10550.6
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 4,
                            ImageGuid = new Guid("4f1e7689-88a4-4a73-9b01-5017918e6e50"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Samsung-s20",
                            ProductPrice = 10550.6
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 4,
                            ImageGuid = new Guid("f5ef19af-814e-480a-93b0-6b0eda1c5bc5"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Samsung-s20",
                            ProductPrice = 10550.6
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 4,
                            ImageGuid = new Guid("b72151b3-4dc5-4308-8550-e5eb73ea9d48"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Samsung-s20",
                            ProductPrice = 10550.6
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 4,
                            ImageGuid = new Guid("26d8a65e-3b7d-4098-9a6f-bfed32df856d"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Samsung-s20",
                            ProductPrice = 10550.6
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 4,
                            ImageGuid = new Guid("cc2518d0-7f0f-4238-a3fa-28a24ee45fb2"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Samsung-s20",
                            ProductPrice = 10550.6
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 4,
                            ImageGuid = new Guid("6c171a22-345f-4684-bde9-401cead1eee0"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Samsung-s20",
                            ProductPrice = 10550.6
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 4,
                            ImageGuid = new Guid("452e13ee-f7f0-425d-aa37-544524bc31ac"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Samsung-s20",
                            ProductPrice = 10550.6
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 4,
                            ImageGuid = new Guid("80899eb2-da1d-4424-8e74-4bcbbf1c50ac"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Samsung-s20",
                            ProductPrice = 10550.6
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 4,
                            ImageGuid = new Guid("63f2a6cb-11fd-498f-a2d5-913e1f180e1b"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Samsung-s20",
                            ProductPrice = 10550.6
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryId = 4,
                            ImageGuid = new Guid("0849f179-949f-4e54-aee0-97121f1d783a"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Samsung-s20",
                            ProductPrice = 10550.6
                        },
                        new
                        {
                            ProductId = 12,
                            CategoryId = 4,
                            ImageGuid = new Guid("4a39f91d-2f2a-4e3f-92c0-455b9ea7efac"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Samsung-s20",
                            ProductPrice = 10550.6
                        },
                        new
                        {
                            ProductId = 13,
                            CategoryId = 4,
                            ImageGuid = new Guid("d9c02f93-ef34-451c-a4c8-866ab0b6f180"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Samsung-s20",
                            ProductPrice = 10550.6
                        },
                        new
                        {
                            ProductId = 14,
                            CategoryId = 1,
                            ImageGuid = new Guid("a31c5418-cd7e-4526-814c-eeb9946486a4"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Hoparlor",
                            ProductPrice = 500.0
                        },
                        new
                        {
                            ProductId = 15,
                            CategoryId = 1,
                            ImageGuid = new Guid("960919f9-9e60-4f6d-8ba4-582b871261c1"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Hoparlor",
                            ProductPrice = 500.0
                        },
                        new
                        {
                            ProductId = 16,
                            CategoryId = 1,
                            ImageGuid = new Guid("fd4d139b-94c9-4159-80cb-9909b4ab0f58"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Hoparlor",
                            ProductPrice = 500.0
                        },
                        new
                        {
                            ProductId = 17,
                            CategoryId = 1,
                            ImageGuid = new Guid("c6829f85-351d-46e8-8f8a-2d1fd8e20590"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Hoparlor",
                            ProductPrice = 500.0
                        },
                        new
                        {
                            ProductId = 18,
                            CategoryId = 1,
                            ImageGuid = new Guid("1e5b8eab-ed7a-4995-bbfc-519badcc5439"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Hoparlor",
                            ProductPrice = 500.0
                        },
                        new
                        {
                            ProductId = 19,
                            CategoryId = 1,
                            ImageGuid = new Guid("ce1bce07-095a-40ae-b9fa-0a3dfb9e575d"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Hoparlor",
                            ProductPrice = 500.0
                        },
                        new
                        {
                            ProductId = 20,
                            CategoryId = 1,
                            ImageGuid = new Guid("f5cd750e-421d-48b5-bef5-5837c9e73c8e"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Hoparlor",
                            ProductPrice = 500.0
                        },
                        new
                        {
                            ProductId = 21,
                            CategoryId = 1,
                            ImageGuid = new Guid("c4a57cdf-a74e-4799-b87c-4f128e16d0ef"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Hoparlor",
                            ProductPrice = 500.0
                        },
                        new
                        {
                            ProductId = 22,
                            CategoryId = 1,
                            ImageGuid = new Guid("4e79d0cb-9b75-4cfb-b530-4a83e1eb8297"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Hoparlor",
                            ProductPrice = 500.0
                        },
                        new
                        {
                            ProductId = 23,
                            CategoryId = 1,
                            ImageGuid = new Guid("ab43c4bc-1bc6-42f8-8297-c50e7ba3a641"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Hoparlor",
                            ProductPrice = 500.0
                        },
                        new
                        {
                            ProductId = 24,
                            CategoryId = 1,
                            ImageGuid = new Guid("82ca1768-18db-4867-9dfe-d8ff14fa488e"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Hoparlor",
                            ProductPrice = 500.0
                        },
                        new
                        {
                            ProductId = 25,
                            CategoryId = 1,
                            ImageGuid = new Guid("f462626d-2f79-4625-80d0-836f05017918"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Hoparlor",
                            ProductPrice = 500.0
                        },
                        new
                        {
                            ProductId = 26,
                            CategoryId = 1,
                            ImageGuid = new Guid("b09b3bd1-ec67-4169-9428-478cf99fa853"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Hoparlor",
                            ProductPrice = 500.0
                        },
                        new
                        {
                            ProductId = 27,
                            CategoryId = 2,
                            ImageGuid = new Guid("7fe141d2-ea1c-490c-830c-c7703aff81f2"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Selpak",
                            ProductPrice = 100.0
                        },
                        new
                        {
                            ProductId = 28,
                            CategoryId = 2,
                            ImageGuid = new Guid("5a7e96ea-dc10-4191-9e41-7a9f7d22a950"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Selpak",
                            ProductPrice = 100.0
                        },
                        new
                        {
                            ProductId = 29,
                            CategoryId = 2,
                            ImageGuid = new Guid("41b08a0d-bfbf-4736-b213-1b03b80b9c72"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Selpak",
                            ProductPrice = 100.0
                        },
                        new
                        {
                            ProductId = 30,
                            CategoryId = 2,
                            ImageGuid = new Guid("30f46ece-cdae-40ec-b8ad-f552f50d732d"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Selpak",
                            ProductPrice = 100.0
                        },
                        new
                        {
                            ProductId = 31,
                            CategoryId = 2,
                            ImageGuid = new Guid("1d502dfd-b4e2-4318-a68e-4e8f0522361f"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Selpak",
                            ProductPrice = 100.0
                        },
                        new
                        {
                            ProductId = 32,
                            CategoryId = 2,
                            ImageGuid = new Guid("30e69ece-232c-4193-b293-59c2208c2833"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Selpak",
                            ProductPrice = 100.0
                        },
                        new
                        {
                            ProductId = 33,
                            CategoryId = 2,
                            ImageGuid = new Guid("c31a5c2a-9828-477c-9a84-925158ec2efe"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Selpak",
                            ProductPrice = 100.0
                        },
                        new
                        {
                            ProductId = 34,
                            CategoryId = 2,
                            ImageGuid = new Guid("1e9d3293-9674-4db2-b71a-6b2c6ff3a851"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Selpak",
                            ProductPrice = 100.0
                        },
                        new
                        {
                            ProductId = 35,
                            CategoryId = 2,
                            ImageGuid = new Guid("43e3dd4d-9ec8-476e-aa66-a6417e401f03"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Selpak",
                            ProductPrice = 100.0
                        },
                        new
                        {
                            ProductId = 36,
                            CategoryId = 2,
                            ImageGuid = new Guid("e7ace810-25e7-4958-a715-3572062cb9f3"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Selpak",
                            ProductPrice = 100.0
                        },
                        new
                        {
                            ProductId = 37,
                            CategoryId = 2,
                            ImageGuid = new Guid("ae9545e4-bb7d-4ecd-a6c7-c0eeb082f2c9"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Selpak",
                            ProductPrice = 100.0
                        },
                        new
                        {
                            ProductId = 38,
                            CategoryId = 2,
                            ImageGuid = new Guid("9d6c9a83-fc7b-4a27-95b7-fbd105d506f0"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Selpak",
                            ProductPrice = 100.0
                        },
                        new
                        {
                            ProductId = 39,
                            CategoryId = 2,
                            ImageGuid = new Guid("6121aabd-9225-4a47-b392-642cc37417c3"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Selpak",
                            ProductPrice = 100.0
                        },
                        new
                        {
                            ProductId = 40,
                            CategoryId = 3,
                            ImageGuid = new Guid("3d53d9b3-4884-46a8-abf0-1ccd6d4519dd"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Sozcu",
                            ProductPrice = 2.0
                        },
                        new
                        {
                            ProductId = 41,
                            CategoryId = 3,
                            ImageGuid = new Guid("0c3662b5-6fc7-475d-a1bb-28ae5e97002f"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Sozcu",
                            ProductPrice = 2.0
                        },
                        new
                        {
                            ProductId = 42,
                            CategoryId = 3,
                            ImageGuid = new Guid("35af930f-3dfe-4e7a-ae3d-ee54d351dd9e"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Sozcu",
                            ProductPrice = 2.0
                        },
                        new
                        {
                            ProductId = 43,
                            CategoryId = 3,
                            ImageGuid = new Guid("d81afe34-4d9a-445f-b4df-41b8d859ed98"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Sozcu",
                            ProductPrice = 2.0
                        },
                        new
                        {
                            ProductId = 44,
                            CategoryId = 3,
                            ImageGuid = new Guid("0385cba1-d759-44c4-8166-c36e0fbefbd3"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Sozcu",
                            ProductPrice = 2.0
                        },
                        new
                        {
                            ProductId = 45,
                            CategoryId = 3,
                            ImageGuid = new Guid("c4967a58-61f7-4b09-8367-2b46df988fc3"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Sozcu",
                            ProductPrice = 2.0
                        },
                        new
                        {
                            ProductId = 46,
                            CategoryId = 3,
                            ImageGuid = new Guid("380232a2-b065-431a-bffe-3cfe4e158938"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Sozcu",
                            ProductPrice = 2.0
                        },
                        new
                        {
                            ProductId = 47,
                            CategoryId = 3,
                            ImageGuid = new Guid("d062e600-3a15-4891-8609-11b5774d11cc"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Sozcu",
                            ProductPrice = 2.0
                        },
                        new
                        {
                            ProductId = 48,
                            CategoryId = 3,
                            ImageGuid = new Guid("5045f5c8-1f5f-4853-b587-7f63f0d82b4a"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Sozcu",
                            ProductPrice = 2.0
                        },
                        new
                        {
                            ProductId = 49,
                            CategoryId = 3,
                            ImageGuid = new Guid("2c408cc5-1c62-42e8-8151-5796274d72f4"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Sozcu",
                            ProductPrice = 2.0
                        },
                        new
                        {
                            ProductId = 50,
                            CategoryId = 3,
                            ImageGuid = new Guid("3439cbfe-ad5d-4bb4-a355-739f09d68b90"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Sozcu",
                            ProductPrice = 2.0
                        },
                        new
                        {
                            ProductId = 51,
                            CategoryId = 3,
                            ImageGuid = new Guid("43426a86-2f53-4c8b-b548-e7207f7394ec"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Sozcu",
                            ProductPrice = 2.0
                        },
                        new
                        {
                            ProductId = 52,
                            CategoryId = 3,
                            ImageGuid = new Guid("f977e36d-7255-4016-bf6e-305593b58fb6"),
                            IsDeleted = false,
                            ProductDescription = "Cok ucuz",
                            ProductName = "Sozcu",
                            ProductPrice = 2.0
                        });
                });

            modelBuilder.Entity("Entities.Order", b =>
                {
                    b.HasOne("Entities.Customer", "Customer")
                        .WithOne("order")
                        .HasForeignKey("Entities.Order", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Entities.OrderItem", b =>
                {
                    b.HasOne("Entities.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.HasOne("Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Customer", b =>
                {
                    b.Navigation("order")
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
