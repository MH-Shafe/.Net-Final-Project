namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeNameOfuserTableToUserEF : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "UserEFs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserEFs", newName: "Users");
        }
    }
}
