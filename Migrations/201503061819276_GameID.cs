namespace Assassins.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GameID", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GameID");
        }
    }
}
