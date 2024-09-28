using Mahalo.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mahalo.Back.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Disorder> Disorders { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<NotificationHistory> NotificationsHistory { get; set; }

        public DbSet<NotificationSchedulingResource> NotificationSchedulingResources { get; set; }

        public DbSet<NotificationScheduling> NotificationSechedulings { get; set; }

        public DbSet<Psychologist> Psychologists { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<ResourceDisorder> ResourcesDisorder { get; set; }

        public DbSet<State> State { get; set; }

        public DbSet<Terapy> Terapy { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
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