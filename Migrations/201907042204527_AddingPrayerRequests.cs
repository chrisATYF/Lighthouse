namespace Lighthouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPrayerRequests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrayerRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestDetails = c.String(),
                        DateSubmitted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PrayerRequests");
        }
    }
}
