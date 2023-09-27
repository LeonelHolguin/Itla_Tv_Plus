using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Database.Models;

namespace Database.Contexts
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
        
        }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Flient API
            #region tables
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Producer>().ToTable("Producers");
            modelBuilder.Entity<Gender>().ToTable("Genders");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Serie>().HasKey(serie => serie.SerieId); //lambda
            modelBuilder.Entity<Producer>().HasKey(producer => producer.ProducerId);
            modelBuilder.Entity<Gender>().HasKey(gender => gender.GenderId);
            #endregion

            #region relationships
            modelBuilder.Entity<Producer>()
                .HasMany<Serie>(producer => producer.SeriesByProducer)
                .WithOne(serie => serie.Producer)
                .HasForeignKey(serie => serie.ProducerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Gender>()
                .HasMany<Serie>(gender => gender.PrimarySeries)
                .WithOne(serie => serie.PrimaryGender)
                .HasForeignKey(serie => serie.PrimaryGenderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Gender>()
                .HasMany<Serie>(gender => gender.SecondarySeries)
                .WithOne(serie => serie.SecondaryGender)
                .HasForeignKey(serie => serie.SecondaryGenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired(false);
            #endregion

            #region "Property configurations"

            #region serie
            modelBuilder.Entity<Serie>().Property(p => p.SerieName)
                .IsRequired().HasMaxLength(60);

            modelBuilder.Entity<Serie>().Property(p => p.ImagePath)
                .IsRequired();

            modelBuilder.Entity<Serie>().Property(p => p.VideoPath)
                .IsRequired();
            #endregion


            #region producer
            modelBuilder.Entity<Producer>().Property(p => p.ProducerName)
                .IsRequired().HasMaxLength(40);
            #endregion


            #region gender
            modelBuilder.Entity<Gender>().Property(p => p.GenderName)
                .IsRequired().HasMaxLength(20);
            #endregion
            #endregion
        }
    }
}
