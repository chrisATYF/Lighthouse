namespace Lighthouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAppUserToMessagesAndRequests : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "AppUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "AppUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.PrayerRequests", "AppUserId", c => c.Int(nullable: false));
            AddColumn("dbo.PrayerRequests", "AppUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Messages", "AppUser_Id");
            CreateIndex("dbo.PrayerRequests", "AppUser_Id");
            AddForeignKey("dbo.Messages", "AppUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PrayerRequests", "AppUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Messages", "AspNetUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "AspNetUserId", c => c.String());
            DropForeignKey("dbo.PrayerRequests", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PrayerRequests", new[] { "AppUser_Id" });
            DropIndex("dbo.Messages", new[] { "AppUser_Id" });
            DropColumn("dbo.PrayerRequests", "AppUser_Id");
            DropColumn("dbo.PrayerRequests", "AppUserId");
            DropColumn("dbo.Messages", "AppUser_Id");
            DropColumn("dbo.Messages", "AppUserId");
        }
    }
}
