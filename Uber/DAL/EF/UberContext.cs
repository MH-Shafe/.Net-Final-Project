using DAL.EF.Entites;
using DAL.EF.Entites.Admin;
using DAL.EF.Entites.Driver;
using DAL.EF.Entites.User;
using DAL.EF.Entities.Driver;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    internal class UberContext : DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<SignUp> SignUps { get; set; }
        public DbSet<SignUp_D> SignUp_Ds { get; set; }

        public DbSet<DriverEF> DriverEFs { get; set; } // Add DbSet for User entity
        public DbSet<Payment> Payments { get; set; } // DbSet for Payment_u entity

        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Login>()
            .HasRequired(l => l.SignUp)  // Assuming Login has a reference to SignUp
            .WithMany()
            .HasForeignKey(l => l.SignUpId);
            // Define relationship between DriverEF and Payment
            modelBuilder.Entity<Payment>()
                .HasRequired(p => p.Driver)  // Each Payment must have a corresponding Driver
                .WithMany(d => d.Payments)   // Each Driver can have multiple Payments
                .HasForeignKey(p => p.DriverID); // Define the foreign key property

          
        }
    }
}
