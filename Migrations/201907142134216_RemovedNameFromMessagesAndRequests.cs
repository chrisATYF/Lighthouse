namespace Lighthouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedNameFromMessagesAndRequests : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Name", c => c.String());
        }
    }
}
