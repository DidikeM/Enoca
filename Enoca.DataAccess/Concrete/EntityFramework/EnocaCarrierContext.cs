using Enoca.Entities.Abstract;
using Enoca.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.DataAccess.Concrete.EntityFramework
{
    public class EnocaCarrierContext : DbContext
    {
        public EnocaCarrierContext()
        {
        }
        public EnocaCarrierContext(DbContextOptions<EnocaCarrierContext> options) : base(options)
        {
        }

        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }
        public DbSet<Order> Orders { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrier>(entity =>
            {
                entity.HasKey(e => e.CarrierId);
            });

            modelBuilder.Entity<CarrierConfiguration>(entity =>
            {
                entity.HasKey(e => e.CarrierConfigurationId);

                entity.HasOne(e => e.Carrier)
                    .WithMany(p => p.CarrierConfigurations)
                    .HasForeignKey(e => e.CarrierId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.HasOne(e => e.Carrier)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(e => e.CarrierId);
            });
        }
    }
}
