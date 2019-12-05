﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using the_great_bible_of_hunger.Data;

namespace the_great_bible_of_hunger.Migrations
{
    [DbContext(typeof(GBOHContext))]
    [Migration("20191205085509_settingUp")]
    partial class settingUp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("the_great_bible_of_hunger.Models.Cuisine", b =>
                {
                    b.Property<int>("CuisineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CuisineID");

                    b.ToTable("Cuisine");

                    b.HasData(
                        new
                        {
                            CuisineID = 1,
                            Name = "Asian"
                        },
                        new
                        {
                            CuisineID = 2,
                            Name = "Italian"
                        },
                        new
                        {
                            CuisineID = 3,
                            Name = "Indian"
                        });
                });

            modelBuilder.Entity("the_great_bible_of_hunger.Models.Diet", b =>
                {
                    b.Property<int>("DietID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DietID");

                    b.ToTable("Diet");

                    b.HasData(
                        new
                        {
                            DietID = 1,
                            Name = "Vegan"
                        },
                        new
                        {
                            DietID = 2,
                            Name = "Vegetarian"
                        },
                        new
                        {
                            DietID = 3,
                            Name = "Gluten-free"
                        });
                });

            modelBuilder.Entity("the_great_bible_of_hunger.Models.DishType", b =>
                {
                    b.Property<int>("DishTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DishTypeID");

                    b.ToTable("DishType");

                    b.HasData(
                        new
                        {
                            DishTypeID = 1,
                            Name = "Breakfast"
                        },
                        new
                        {
                            DishTypeID = 2,
                            Name = "Dinner"
                        },
                        new
                        {
                            DishTypeID = 3,
                            Name = "Lunch"
                        },
                        new
                        {
                            DishTypeID = 4,
                            Name = "Dessert"
                        });
                });

            modelBuilder.Entity("the_great_bible_of_hunger.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredientID");

                    b.ToTable("Ingredient");

                    b.HasData(
                        new
                        {
                            IngredientID = 1,
                            ImageURL = "",
                            Name = "Tomato",
                            Type = "Vegetable"
                        },
                        new
                        {
                            IngredientID = 2,
                            ImageURL = "",
                            Name = "Cucumber",
                            Type = "Vegetable"
                        },
                        new
                        {
                            IngredientID = 3,
                            ImageURL = "",
                            Name = "Pork",
                            Type = "Meat"
                        },
                        new
                        {
                            IngredientID = 4,
                            ImageURL = "",
                            Name = "Spaghetti",
                            Type = "Pasta"
                        },
                        new
                        {
                            IngredientID = 5,
                            ImageURL = "",
                            Name = "Rise",
                            Type = "Grain"
                        });
                });

            modelBuilder.Entity("the_great_bible_of_hunger.Models.Rating", b =>
                {
                    b.Property<int>("RatingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ReviewsNumber")
                        .HasColumnType("int");

                    b.Property<double>("Stars")
                        .HasColumnType("float");

                    b.HasKey("RatingID");

                    b.ToTable("Rating");

                    b.HasData(
                        new
                        {
                            RatingID = 1,
                            ReviewsNumber = 1,
                            Stars = 5.0
                        },
                        new
                        {
                            RatingID = 2,
                            ReviewsNumber = 156,
                            Stars = 4.2999999999999998
                        },
                        new
                        {
                            RatingID = 3,
                            ReviewsNumber = 20,
                            Stars = 3.7999999999999998
                        });
                });

            modelBuilder.Entity("the_great_bible_of_hunger.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CuisineID")
                        .HasColumnType("int");

                    b.Property<int>("DishTypeID")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RatingID")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecipeID");

                    b.HasIndex("CuisineID");

                    b.HasIndex("DishTypeID");

                    b.HasIndex("RatingID");

                    b.ToTable("Recipe");

                    b.HasData(
                        new
                        {
                            RecipeID = 1,
                            CuisineID = 1,
                            DishTypeID = 1,
                            ImageURL = "https://via.placeholder.com/150",
                            Price = 70m,
                            RatingID = 1,
                            Time = 20,
                            Title = "Placeholder dish"
                        },
                        new
                        {
                            RecipeID = 2,
                            CuisineID = 2,
                            DishTypeID = 3,
                            ImageURL = "https://via.placeholder.com/150",
                            Price = 80m,
                            RatingID = 2,
                            Time = 40,
                            Title = "Placeholder dish"
                        },
                        new
                        {
                            RecipeID = 3,
                            CuisineID = 3,
                            DishTypeID = 4,
                            ImageURL = "https://via.placeholder.com/150",
                            Price = 65m,
                            RatingID = 3,
                            Time = 60,
                            Title = "Placeholder dish"
                        });
                });

            modelBuilder.Entity("the_great_bible_of_hunger.Models.RecipeDiet", b =>
                {
                    b.Property<int>("DietID")
                        .HasColumnType("int");

                    b.Property<int>("RecipeID")
                        .HasColumnType("int");

                    b.HasKey("DietID", "RecipeID");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeDiet");
                });

            modelBuilder.Entity("the_great_bible_of_hunger.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("IngredientID")
                        .HasColumnType("int");

                    b.Property<int>("RecipeID")
                        .HasColumnType("int");

                    b.HasKey("IngredientID", "RecipeID");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("the_great_bible_of_hunger.Models.Recipe", b =>
                {
                    b.HasOne("the_great_bible_of_hunger.Models.Cuisine", "Cuisine")
                        .WithMany("Recipes")
                        .HasForeignKey("CuisineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("the_great_bible_of_hunger.Models.DishType", "DishType")
                        .WithMany("Recipes")
                        .HasForeignKey("DishTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("the_great_bible_of_hunger.Models.Rating", "Rating")
                        .WithMany("Recipes")
                        .HasForeignKey("RatingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("the_great_bible_of_hunger.Models.RecipeDiet", b =>
                {
                    b.HasOne("the_great_bible_of_hunger.Models.Diet", "Diet")
                        .WithMany("RecipeDiets")
                        .HasForeignKey("DietID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("the_great_bible_of_hunger.Models.Recipe", "Recipe")
                        .WithMany("RecipeDiets")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("the_great_bible_of_hunger.Models.RecipeIngredient", b =>
                {
                    b.HasOne("the_great_bible_of_hunger.Models.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("the_great_bible_of_hunger.Models.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
