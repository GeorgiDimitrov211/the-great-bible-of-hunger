using System;
using Microsoft.EntityFrameworkCore;
using the_great_bible_of_hunger.Models;

namespace the_great_bible_of_hunger.Data {
    public class GBOHContext : DbContext {
        public GBOHContext(DbContextOptions<GBOHContext> options) : base(options) {

        }
        public DbSet<Cuisine> Cuisines { get;set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<DishType> DishTypes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Recipe> Recipes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Cuisine>().ToTable("Cuisine");
            modelBuilder.Entity<Diet>().ToTable("Diet");
            modelBuilder.Entity<DishType>().ToTable("DishType");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
            modelBuilder.Entity<Rating>().ToTable("Rating");
            modelBuilder.Entity<Recipe>().ToTable("Recipe");
        }

    }
}
