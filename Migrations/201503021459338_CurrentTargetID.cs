namespace Assassins.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrentTargetID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CurrentTargetID", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CurrentTargetID");
        }
    }
}
