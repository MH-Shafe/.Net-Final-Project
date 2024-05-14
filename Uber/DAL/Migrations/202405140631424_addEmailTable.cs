namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sender = c.String(nullable: false, maxLength: 255),
                        Recipient = c.String(nullable: false, maxLength: 255),
                        Subject = c.String(maxLength: 255),
                        Body = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Emails");
        }
    }
}
