namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRelationshipWithLoginAndSignUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "SignUpId", c => c.Int(nullable: false));
            AddColumn("dbo.SignUps", "Login_Id", c => c.Int());
            CreateIndex("dbo.Logins", "SignUpId");
            CreateIndex("dbo.SignUps", "Login_Id");
            AddForeignKey("dbo.SignUps", "Login_Id", "dbo.Logins", "Id");
            AddForeignKey("dbo.Logins", "SignUpId", "dbo.SignUps", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "SignUpId", "dbo.SignUps");
            DropForeignKey("dbo.SignUps", "Login_Id", "dbo.Logins");
            DropIndex("dbo.SignUps", new[] { "Login_Id" });
            DropIndex("dbo.Logins", new[] { "SignUpId" });
            DropColumn("dbo.SignUps", "Login_Id");
            DropColumn("dbo.Logins", "SignUpId");
        }
    }
}
