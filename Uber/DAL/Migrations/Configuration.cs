namespace DAL.Migrations
{
    using DAL.EF.Entities.Driver;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.UberContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.UberContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            /*
            for (int i = 0; i < 10; i++) {
                context.Logins.AddOrUpdate(new EF.Entites.Login
                {
                     username = "User-"+i,
                    password = Guid.NewGuid().ToString().Substring(0,10),
                    roll= "Genaral"
                });
            }  
            
            for (int i = 0; i < 10; i++)
            {
                context.SignUps.AddOrUpdate(new EF.Entites.Admin.SignUp
                {
                    username = "User-" + i,
                    Name = "User Name " + i,
                    Email = "user" + i + "@example.com",
                    Country = "Country " + i
                });
            }

            context.SaveChanges();
            */

            /*
            if (!context.Logins.Any() && !context.SignUps.Any())
            {
                // Add data to SignUps table
                for (int i = 0; i < 10; i++)
                {
                    context.SignUps.AddOrUpdate(new EF.Entites.Admin.SignUp
                    {
                        Id = i + 1, // Assuming SignUp Id starts from 1
                        username = "User-" + i,
                        Name = "User Name " + i,
                        Email = "user" + i + "@example.com",
                        Country = "Country " + i
                    });
                }

                // Save changes to SignUps
                context.SaveChanges();

                // Add data to Logins table
                for (int i = 0; i < 10; i++)
                {
                    context.Logins.AddOrUpdate(new EF.Entites.Login
                    {
                        Id = i + 1, // Assuming Login Id starts from 1
                        username = "User-" + i,
                        password = Guid.NewGuid().ToString().Substring(0, 10),
                        roll = "General",
                        SignUpId = i + 1 // Set SignUpId to match the corresponding SignUp record
                    });
                }

                // Save changes to Logins
                context.SaveChanges();
            }
            */
            // Seeding Drivers
            /*
            for (int i = 0; i < 10; i++)
            {
                context.DriverEFs.AddOrUpdate(new DriverEF
                {
                    Username = "Driver-" + i,
                    Email = $"driver{i}@example.com",
                    Password = "password" + i,
                    PhoneNumber = "12345678" + i
                });
            }

            // Seed Payments
            for (int i = 0; i < 10; i++)
            {
                context.Payments.AddOrUpdate(new Payment
                {
                    PaymentMethod = "Credit Card",
                    TransactionAmount = 50.00m + (i * 5), // Increasing amount for each payment
                    Timestamp = DateTime.Now.AddDays(-i) // Changing timestamp for each payment
                });
            }

            // Save changes to the database
            context.SaveChanges();
           */ 
        }
    }
}
