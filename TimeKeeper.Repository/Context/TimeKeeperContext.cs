using Microsoft.EntityFrameworkCore;
using TimeKeeper.Domain.Models;

#nullable disable

namespace TimeKeeper.Repository
{
    public partial class TimeKeeperContext : DbContext
    {
        private readonly string _connectionString;

        public TimeKeeperContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public virtual DbSet<TimeEntry> TimeEntries { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");            

            modelBuilder.Entity<TimeEntry>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Hours).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
