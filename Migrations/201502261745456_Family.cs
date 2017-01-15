namespace Assassins.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Family : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Family", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Family");
        }
    }
}
