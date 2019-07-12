namespace Lighthouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDisplayNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "AspNetUserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "AspNetUserId");
        }
    }
}
