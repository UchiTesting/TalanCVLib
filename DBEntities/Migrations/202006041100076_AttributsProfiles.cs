namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttributsProfiles : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "LastName", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "LastName", c => c.String());
        }
    }
}
