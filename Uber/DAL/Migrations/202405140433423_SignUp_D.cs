namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SignUp_D : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SignUp_D", "Phone_Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SignUp_D", "Phone_Number", c => c.String());
        }
    }
}
