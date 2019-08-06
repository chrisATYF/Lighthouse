namespace Lighthouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingUserPhotos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "AspNetUserId_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.UserProfiles", "UserPhoto_Id", c => c.Int());
            CreateIndex("dbo.UserProfiles", "AspNetUserId_Id");
            CreateIndex("dbo.UserProfiles", "UserPhoto_Id");
            AddForeignKey("dbo.UserProfiles", "AspNetUserId_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserProfiles", "UserPhoto_Id", "dbo.UploadFiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "UserPhoto_Id", "dbo.UploadFiles");
            DropForeignKey("dbo.UserProfiles", "AspNetUserId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserProfiles", new[] { "UserPhoto_Id" });
            DropIndex("dbo.UserProfiles", new[] { "AspNetUserId_Id" });
            DropColumn("dbo.UserProfiles", "UserPhoto_Id");
            DropColumn("dbo.UserProfiles", "AspNetUserId_Id");
        }
    }
}
