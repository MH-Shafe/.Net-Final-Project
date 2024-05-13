namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDriverInfoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DriverInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicenseNumber = c.String(),
                        LicenseExpiration = c.DateTime(nullable: false),
                        VehicleModel = c.String(),
                        VehiclePlateNumber = c.String(),
                        SignUpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SignUps", t => t.SignUpId, cascadeDelete: true)
                .Index(t => t.SignUpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DriverInfoes", "SignUpId", "dbo.SignUps");
            DropIndex("dbo.DriverInfoes", new[] { "SignUpId" });
            DropTable("dbo.DriverInfoes");
        }
    }
}
