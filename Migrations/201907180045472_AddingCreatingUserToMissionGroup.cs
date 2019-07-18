namespace Lighthouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCreatingUserToMissionGroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MissionGroupApplicationUsers", "MissionGroup_Id", "dbo.MissionGroups");
            DropForeignKey("dbo.MissionGroupApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MissionGroupApplicationUsers", new[] { "MissionGroup_Id" });
            DropIndex("dbo.MissionGroupApplicationUsers", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.AspNetUsers", "MissionGroup_Id", c => c.Int());
            AddColumn("dbo.MissionGroups", "GroupCreator_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.MissionGroups", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "MissionGroup_Id");
            CreateIndex("dbo.MissionGroups", "GroupCreator_Id");
            CreateIndex("dbo.MissionGroups", "ApplicationUser_Id");
            AddForeignKey("dbo.MissionGroups", "GroupCreator_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "MissionGroup_Id", "dbo.MissionGroups", "Id");
            AddForeignKey("dbo.MissionGroups", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropTable("dbo.MissionGroupApplicationUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MissionGroupApplicationUsers",
                c => new
                    {
                        MissionGroup_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MissionGroup_Id, t.ApplicationUser_Id });
            
            DropForeignKey("dbo.MissionGroups", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "MissionGroup_Id", "dbo.MissionGroups");
            DropForeignKey("dbo.MissionGroups", "GroupCreator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MissionGroups", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.MissionGroups", new[] { "GroupCreator_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "MissionGroup_Id" });
            DropColumn("dbo.MissionGroups", "ApplicationUser_Id");
            DropColumn("dbo.MissionGroups", "GroupCreator_Id");
            DropColumn("dbo.AspNetUsers", "MissionGroup_Id");
            CreateIndex("dbo.MissionGroupApplicationUsers", "ApplicationUser_Id");
            CreateIndex("dbo.MissionGroupApplicationUsers", "MissionGroup_Id");
            AddForeignKey("dbo.MissionGroupApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MissionGroupApplicationUsers", "MissionGroup_Id", "dbo.MissionGroups", "Id", cascadeDelete: true);
        }
    }
}
