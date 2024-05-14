namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPaymentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payment_u",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        PaymentMethod = c.String(),
                        TransactionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Timestamp = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payment_u", "UserID", "dbo.Users");
            DropIndex("dbo.Payment_u", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Payment_u");
        }
    }
}
