namespace Assassins.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrentTarget : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CurrentTarget", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CurrentTarget");
        }
    }
}
