using Mahalo.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mahalo.Back.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<Country> Countries { get; set; }

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
