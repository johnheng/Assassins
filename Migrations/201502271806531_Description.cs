namespace Assassins.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Description : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.AspNetUsers", "UserNameIndex");
            AddColumn("dbo.AspNetUsers", "Description", c => c.String());
            //AlterColumn("dbo.AspNetUsers", "Username", c => c.String());
            //CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
        }
        
        public override void Down()
        {
            //DropIndex("dbo.AspNetUsers", "UserNameIndex");
            //AlterColumn("dbo.AspNetUsers", "Username", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.AspNetUsers", "Description");
            //CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
        }
    }
}
