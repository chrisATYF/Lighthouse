namespace Lighthouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCountriesToMissionGroups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MissionGroups", "Country", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MissionGroups", "Country");
        }
    }
}
