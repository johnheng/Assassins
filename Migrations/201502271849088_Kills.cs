namespace Assassins.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kills : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Kills", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Kills");
        }
    }
}
