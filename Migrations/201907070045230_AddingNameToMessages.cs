namespace Lighthouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNameToMessages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Name");
        }
    }
}
