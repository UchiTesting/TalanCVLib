namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class toto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hobbies",
                c => new
                    {
                        ProfileID = c.Int(nullable: false),
                        TitleID = c.Int(nullable: false),
                        HobbieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProfileID, t.TitleID })
                .ForeignKey("dbo.Profiles", t => t.ProfileID, cascadeDelete: true)
                .ForeignKey("dbo.Titles", t => t.TitleID, cascadeDelete: true)
                .Index(t => t.ProfileID)
                .Index(t => t.TitleID);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TitleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hobbies", "TitleID", "dbo.Titles");
            DropForeignKey("dbo.Hobbies", "ProfileID", "dbo.Profiles");
            DropIndex("dbo.Hobbies", new[] { "TitleID" });
            DropIndex("dbo.Hobbies", new[] { "ProfileID" });
            DropTable("dbo.Titles");
            DropTable("dbo.Hobbies");
        }
    }
}
