namespace Assassins.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrentTargetID1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "CurrentTargetID", c => c.String(nullable: false, defaultValue: ""));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "CurrentTargetID", c => c.Int());
        }
    }
}
