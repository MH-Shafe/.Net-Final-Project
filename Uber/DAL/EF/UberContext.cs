﻿using DAL.EF.Entites;
using DAL.EF.Entites.Admin;
using DAL.EF.Entites;
using DAL.EF.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF.Entites.User;

namespace DAL.EF
{
    internal class UberContext : DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<SignUp> SignUps { get; set; }
        public DbSet<UserEF> UserEF { get; set; } // Add DbSet for User entity
        public DbSet<Payment_u> Payment_us { get; set; } // DbSet for Payment_u entity
        public DbSet<Subscription_u> Subscription_us { get; set; }
        public DbSet<Ride_u> Ride_us { get; set; }
        public DbSet<Driver_u> Driver_us { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationship between Login and SignUp
            modelBuilder.Entity<Login>()
                .HasRequired(l => l.SignUp)
                .WithMany()
                .HasForeignKey(l => l.SignUpId);

            // Define relationship between User and Payment_u

            modelBuilder.Entity<Payment_u>()
         .HasRequired(p => p.User)
         .WithMany(u => u.Payments)
         .HasForeignKey(p => p.UserID);// Foreign key from Payment_u to User
        }
    }
}
