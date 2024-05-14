namespace DAL.Migrations
{
    using DAL.EF.Entites;
    using DAL.EF.Entites.Admin;
    using DAL.EF.Entities.User;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.UberContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
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

            //masud 
            /*
            var rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                var signUp = new SignUp
                {
                    username = $"user{i}",
                    Name = $"User{i} Name",
                    Email = $"user{i}@example.com",
                    Country = "Unknown"
                };

                var login = new Login
                {
                    username = signUp.username,
                    password = $"password{i}",
                    roll = "User",
                    SignUp = signUp
                };

                context.Set<SignUp>().Add(signUp);
                context.Set<Login>().Add(login);
            }

            context.SaveChanges();
        */
            /*
            for (int i = 0; i < 10; i++)
            {
                var user = new User
                {
                    Username = "User-" + i,
                    Email = $"user{i}@example.com",
                    Password = Guid.NewGuid().ToString().Substring(0, 10),
                    PhoneNumber = $"123456789{i}" // You can modify this according to your data model
                };
                context.Users.AddOrUpdate(user);
            }

            context.SaveChanges(); // Save changes to ensure User IDs are generated

            // Seed Payment_u data
            for (int i = 0; i < 10; i++)
            {
                var payment = new Payment_u
                {
                    PaymentMethod = "Method-" + i,
                    TransactionAmount = (decimal)(i * 100.50), // Example amount
                    Timestamp = DateTime.Now.AddDays(-i), // Example timestamp
                    UserID = i + 1 // Assuming UserIDs start from 1
                };
                context.Payment_us.AddOrUpdate(payment);
            }

            context.SaveChanges();
            */

        }
            

    
    }
}
