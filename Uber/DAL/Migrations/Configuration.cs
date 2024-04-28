namespace DAL.Migrations
{
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
            */
    }
}
}
