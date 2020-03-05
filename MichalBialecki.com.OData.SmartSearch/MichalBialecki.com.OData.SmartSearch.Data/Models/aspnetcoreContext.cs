using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MichalBialecki.com.OData.SmartSearch.Data.Models
{
    public partial class aspnetcoreContext : DbContext
    {
        public aspnetcoreContext()
        {
        }

        public aspnetcoreContext(DbContextOptions<aspnetcoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Profiles> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profiles>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.Property(e => e.Website).HasMaxLength(200);

                entity.Property(e => e.ZipCode).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
