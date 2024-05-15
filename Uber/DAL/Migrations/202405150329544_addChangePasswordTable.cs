namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addChangePasswordTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PasswordChanges",
                c => new
                    {
                        LoginId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        OldPassword = c.String(),
                        NewPassword = c.String(),
                        ChangeRequestedAt = c.DateTime(nullable: false),
                        Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoginId)
                .ForeignKey("dbo.Logins", t => t.LoginId)
                .Index(t => t.LoginId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PasswordChanges", "LoginId", "dbo.Logins");
            DropIndex("dbo.PasswordChanges", new[] { "LoginId" });
            DropTable("dbo.PasswordChanges");
        }
    }
}
