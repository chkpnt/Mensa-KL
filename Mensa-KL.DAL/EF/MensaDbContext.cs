using Mensa_KL.Models;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensa_KL.DAL
{
    public class MensaDbContext : DbContext
    {
        public virtual DbSet<Meal> MealSet { get; set; }
        public virtual DbSet<MealImage> MealImageSet { get; set; }

        protected override void OnConfiguring(DbContextOptions options)
        {
            var connection = "Filename=Mensa-KL.db";

            options.UseSQLite(connection);
        }

        protected override void OnModelCreating(Microsoft.Data.Entity.Metadata.ModelBuilder modelBuilder)
        {
            Disable_GenerateValuesOnAdd(modelBuilder);
        }

        private void Disable_GenerateValuesOnAdd(Microsoft.Data.Entity.Metadata.ModelBuilder modelBuilder)
        {
            // Andernfalls: The 'MealId' on entity type 'Mensa-KL.Models.Meal' is set up to use generated values, but no value generator is available for properties of type 'Int32'. To use value generation for properties of type 'Int32' the data store must configure an appropriate value generator.
            modelBuilder.Entity<Meal>()
                .Property(p => p.MealId)
                .GenerateValuesOnAdd(false);

            modelBuilder.Entity<MealImage>()
                .Property(i => i.MealImageId)
                .GenerateValuesOnAdd(false);
        }
    }
}
