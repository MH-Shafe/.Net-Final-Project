namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSubscriptionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscription_u",
                c => new
                    {
                        SubscriptionID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Duration = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpiryDate = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubscriptionID)
                .ForeignKey("dbo.UserEFs", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscription_u", "UserID", "dbo.UserEFs");
            DropIndex("dbo.Subscription_u", new[] { "UserID" });
            DropTable("dbo.Subscription_u");
        }
    }
}
