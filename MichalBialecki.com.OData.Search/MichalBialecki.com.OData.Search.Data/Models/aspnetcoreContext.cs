using Microsoft.EntityFrameworkCore;

namespace MichalBialecki.com.OData.Search.Data.Models
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

        public DbContext Instance => this;

        public virtual DbSet<Profile> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

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

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.Property(e => e.Website).HasMaxLength(200);

                entity.Property(e => e.ZipCode).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
