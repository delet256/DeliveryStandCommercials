using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryStandCommercials.Models
{
    public class StandCommercialContext : DbContext
    {
        public DbSet<Commercial> Commercials { get; set; }
        public DbSet<Stand> Stands { get; set; }
        public StandCommercialContext()
        {
            Database.EnsureCreated();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StandCommercial>()
                .HasKey(t => new { t.CommercialId, t.StandId });

            modelBuilder.Entity<StandCommercial>()
                .HasOne(sc => sc.Commercial)
                .WithMany(s => s.StandCommercials)
                .HasForeignKey(sc => sc.CommercialId);

            modelBuilder.Entity<StandCommercial>()
                .HasOne(sc => sc.Stand)
                .WithMany(c => c.StandCommercials)
                .HasForeignKey(sc => sc.StandId);
        }

        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=CommercialsTVStanddb;Trusted_Connection=True;Integrated Security=SSPI;AttachDbFileName=c:\\deletTemp\\CommercialsTVStanddb.mdf");
            // optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=33331ffff;Trusted_Connection=True);
            optionsBuilder.UseSqlite("Data Source=orders.db");


        }
    }
}
