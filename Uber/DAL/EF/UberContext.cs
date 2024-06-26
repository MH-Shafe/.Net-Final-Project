﻿using DAL.EF.Entites.Admin;
using DAL.EF.Entites;
using DAL.EF.Entities;
using DAL.EF.Entities.Admin;
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
        public DbSet<DriverInfo> DriverInfos { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<PasswordChange> PasswordChanges { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .HasRequired(l => l.SignUp)
                .WithMany()
                .HasForeignKey(l => l.SignUpId);
            modelBuilder.Entity<Login>()
                .HasOptional(l => l.PasswordChange) // Make PasswordChange optional
                .WithRequired(pc => pc.Login); // PasswordChange must have a Login
            modelBuilder.Entity<PasswordChange>()
                .HasKey(pc => pc.LoginId);
        }
    }
}
