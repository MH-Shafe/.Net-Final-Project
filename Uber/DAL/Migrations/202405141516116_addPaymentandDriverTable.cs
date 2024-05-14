namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addPaymentandDriverTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DriverEFs",
                c => new
                {
                    UserID = c.Int(nullable: false, identity: true),
                    Username = c.String(),
                    Email = c.String(),
                    Password = c.String(),
                })
                .PrimaryKey(t => t.UserID);

            CreateTable(
                "dbo.Payments",
                c => new
                {
                    PaymentID = c.Int(nullable: false, identity: true),
                    PaymentMethod = c.String(),
                    TransactionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Timestamp = c.DateTime(nullable: false),
                    DriverID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.DriverEFs", t => t.DriverID, cascadeDelete: true)
                .Index(t => t.DriverID);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Payments", "DriverID", "dbo.DriverEFs");
            DropIndex("dbo.Payments", new[] { "DriverID" });
            DropTable("dbo.Payments");
            DropTable("dbo.DriverEFs");
        }
    }
}
