using HW4App.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4App.Database.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Store> Stores { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<StoreSubscription> StoresSubscriptions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FWCore_hw4;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(builder =>
            {
                builder.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Store>().HasMany(e => e.Clients).WithMany(e => e.Stores).UsingEntity<StoreSubscription>(builder =>
            {
                builder.ToTable("StoreSubscription");
                builder.HasKey(e => new { e.ClientId, e.StoreId });
                builder.Property(e => e.SubscribedAt).HasDefaultValueSql("GETDATE()");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
