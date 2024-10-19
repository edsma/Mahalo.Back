using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mahalo.Back.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Disorder> Disorders { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<NotificationHistory> NotificationsHistory { get; set; }

        public DbSet<NotificationSchedulingResource> NotificationsSchedulingResources { get; set; }

        public DbSet<NotificationScheduling> NotificationsScheduling { get; set; }

        public DbSet<Psychologist> Psychologists { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<ResourceDisorder> ResourcesDisorder { get; set; }

        public DbSet<State> States { get; set; }
        public DbSet<Terapy> Terapies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<State>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<City>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Psychologist>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Terapy>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<User>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<DocumentType>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Disorder>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<NotificationHistory>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<NotificationScheduling>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<NotificationSchedulingResource>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<ResourceDisorder>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Resource>().HasIndex(x => x.Id).IsUnique();
            DisableCascadingDelete(modelBuilder);
        }

        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationShips = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationShip in relationShips)
            {
                relationShip.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}