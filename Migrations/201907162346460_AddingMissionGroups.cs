namespace Lighthouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMissionGroups : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MissionGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MissionGroupApplicationUsers",
                c => new
                    {
                        MissionGroup_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MissionGroup_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.MissionGroups", t => t.MissionGroup_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.MissionGroup_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.Messages", "MissionGroup_Id", c => c.Int());
            CreateIndex("dbo.Messages", "MissionGroup_Id");
            AddForeignKey("dbo.Messages", "MissionGroup_Id", "dbo.MissionGroups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MissionGroupApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MissionGroupApplicationUsers", "MissionGroup_Id", "dbo.MissionGroups");
            DropForeignKey("dbo.Messages", "MissionGroup_Id", "dbo.MissionGroups");
            DropIndex("dbo.MissionGroupApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.MissionGroupApplicationUsers", new[] { "MissionGroup_Id" });
            DropIndex("dbo.Messages", new[] { "MissionGroup_Id" });
            DropColumn("dbo.Messages", "MissionGroup_Id");
            DropTable("dbo.MissionGroupApplicationUsers");
            DropTable("dbo.MissionGroups");
        }
    }
}
