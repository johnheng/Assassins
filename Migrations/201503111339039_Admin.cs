namespace Assassins.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Admin", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Admin");
        }
    }
}
