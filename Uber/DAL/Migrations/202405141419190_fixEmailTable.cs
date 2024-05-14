namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixEmailTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Emails", "Sender", c => c.String());
            AlterColumn("dbo.Emails", "Recipient", c => c.String());
            AlterColumn("dbo.Emails", "Subject", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Emails", "Subject", c => c.String(maxLength: 255));
            AlterColumn("dbo.Emails", "Recipient", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Emails", "Sender", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
