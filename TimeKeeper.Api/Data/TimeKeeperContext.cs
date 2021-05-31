using Microsoft.EntityFrameworkCore;
using TimeKeeper.Api.Domain;

#nullable disable

namespace TimeKeeper.Api.Data
{
    public partial class TimeKeeperContext : DbContext
    {
        public TimeKeeperContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<TimeEntry> TimeEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TimeEntry>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Hours).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.TimeEntries)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TimeEntries_Categories");

                entity.HasOne(d => d.ClientNavigation)
                    .WithMany(p => p.TimeEntries)
                    .HasForeignKey(d => d.Client)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TimeEntries_Clients");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}