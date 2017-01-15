namespace Assassins.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ImagePath", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ImagePath");
        }
    }
}
