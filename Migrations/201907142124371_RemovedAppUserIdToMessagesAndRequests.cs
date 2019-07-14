namespace Lighthouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAppUserIdToMessagesAndRequests : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "AppUserId");
            DropColumn("dbo.PrayerRequests", "AppUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PrayerRequests", "AppUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "AppUserId", c => c.Int(nullable: false));
        }
    }
}
