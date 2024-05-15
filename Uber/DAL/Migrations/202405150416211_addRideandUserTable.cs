namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRideandUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rides",
                c => new
                    {
                        RideID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        DriverID = c.Int(nullable: false),
                        PickupLocation = c.String(),
                        Destination = c.String(),
                        Fare = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.RideID)
                .ForeignKey("dbo.DriverEFs", t => t.DriverID, cascadeDelete: true)
                .ForeignKey("dbo.UserEFs", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.DriverID);
            
            CreateTable(
                "dbo.UserEFs",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rides", "UserID", "dbo.UserEFs");
            DropForeignKey("dbo.Rides", "DriverID", "dbo.DriverEFs");
            DropIndex("dbo.Rides", new[] { "DriverID" });
            DropIndex("dbo.Rides", new[] { "UserID" });
            DropTable("dbo.UserEFs");
            DropTable("dbo.Rides");
        }
    }
}
