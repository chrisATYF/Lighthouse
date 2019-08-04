namespace Lighthouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUploadFileAndUserProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UploadFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfileId = c.Int(nullable: false),
                        FileName = c.String(),
                        ContentType = c.String(),
                        ContentLength = c.Int(nullable: false),
                        ExternalURL = c.String(),
                        Data = c.Binary(),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        AddDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfiles");
            DropTable("dbo.UploadFiles");
        }
    }
}
