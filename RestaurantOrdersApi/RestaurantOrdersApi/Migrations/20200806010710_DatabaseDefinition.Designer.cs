﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantOrdersApi.Context;

namespace RestaurantOrdersApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200806010710_DatabaseDefinition")]
    partial class DatabaseDefinition
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.2.20120.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestaurantOrdersApi.Entities.Dish", b =>
                {
                    b.Property<int>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DishTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bit");

                    b.HasKey("DishId");

                    b.HasIndex("DishTypeId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("RestaurantOrdersApi.Entities.DishMealTime", b =>
                {
                    b.Property<int>("MealTimeId")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("MaxAllowed")
                        .HasColumnType("int");

                    b.HasKey("MealTimeId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("DishesMealTimes");
                });

            modelBuilder.Entity("RestaurantOrdersApi.Entities.DishType", b =>
                {
                    b.Property<int>("DishTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bit");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.HasKey("DishTypeId");

                    b.ToTable("DishTypes");
                });

            modelBuilder.Entity("RestaurantOrdersApi.Entities.MealTime", b =>
                {
                    b.Property<int>("MealTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bit");

                    b.HasKey("MealTimeId");

                    b.ToTable("MealTimes");
                });

            modelBuilder.Entity("RestaurantOrdersApi.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HasInputError")
                        .HasColumnType("bit");

                    b.Property<int>("MealTimeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestedOrder")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex("MealTimeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RestaurantOrdersApi.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountOrdered")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("DishId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("RestaurantOrdersApi.Entities.Dish", b =>
                {
                    b.HasOne("RestaurantOrdersApi.Entities.DishType", "DishType")
                        .WithMany("Dishes")
                        .HasForeignKey("DishTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantOrdersApi.Entities.DishMealTime", b =>
                {
                    b.HasOne("RestaurantOrdersApi.Entities.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantOrdersApi.Entities.MealTime", "MealTime")
                        .WithMany()
                        .HasForeignKey("MealTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantOrdersApi.Entities.Order", b =>
                {
                    b.HasOne("RestaurantOrdersApi.Entities.MealTime", "MealTime")
                        .WithMany()
                        .HasForeignKey("MealTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantOrdersApi.Entities.OrderItem", b =>
                {
                    b.HasOne("RestaurantOrdersApi.Entities.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantOrdersApi.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
