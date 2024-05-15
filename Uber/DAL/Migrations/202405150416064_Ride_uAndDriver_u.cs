namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ride_uAndDriver_u : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Driver_u",
                c => new
                    {
                        DriverID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.DriverID);
            
            CreateTable(
                "dbo.Ride_u",
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
                .ForeignKey("dbo.Driver_u", t => t.DriverID, cascadeDelete: true)
                .ForeignKey("dbo.UserEFs", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.DriverID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ride_u", "UserID", "dbo.UserEFs");
            DropForeignKey("dbo.Ride_u", "DriverID", "dbo.Driver_u");
            DropIndex("dbo.Ride_u", new[] { "DriverID" });
            DropIndex("dbo.Ride_u", new[] { "UserID" });
            DropTable("dbo.Ride_u");
            DropTable("dbo.Driver_u");
        }
    }
}
