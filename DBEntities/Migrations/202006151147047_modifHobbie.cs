namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifHobbie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hobbies", "TitleID", "dbo.Titles");
            DropForeignKey("dbo.Hobbies", "ProfileID", "dbo.Profiles");
            DropIndex("dbo.Hobbies", new[] { "ProfileID" });
            DropIndex("dbo.Hobbies", new[] { "TitleID" });
            RenameColumn(table: "dbo.Hobbies", name: "ProfileID", newName: "Profile_ProfileID");
            DropPrimaryKey("dbo.Hobbies");
            AddColumn("dbo.Hobbies", "Description", c => c.String());
            AlterColumn("dbo.Hobbies", "Profile_ProfileID", c => c.Int());
            AlterColumn("dbo.Hobbies", "HobbieID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Hobbies", "HobbieID");
            CreateIndex("dbo.Hobbies", "Profile_ProfileID");
            AddForeignKey("dbo.Hobbies", "Profile_ProfileID", "dbo.Profiles", "ProfileID");
            DropColumn("dbo.Hobbies", "TitleID");
            DropTable("dbo.Titles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TitleID);
            
            AddColumn("dbo.Hobbies", "TitleID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Hobbies", "Profile_ProfileID", "dbo.Profiles");
            DropIndex("dbo.Hobbies", new[] { "Profile_ProfileID" });
            DropPrimaryKey("dbo.Hobbies");
            AlterColumn("dbo.Hobbies", "HobbieID", c => c.Int(nullable: false));
            AlterColumn("dbo.Hobbies", "Profile_ProfileID", c => c.Int(nullable: false));
            DropColumn("dbo.Hobbies", "Description");
            AddPrimaryKey("dbo.Hobbies", new[] { "ProfileID", "TitleID" });
            RenameColumn(table: "dbo.Hobbies", name: "Profile_ProfileID", newName: "ProfileID");
            CreateIndex("dbo.Hobbies", "TitleID");
            CreateIndex("dbo.Hobbies", "ProfileID");
            AddForeignKey("dbo.Hobbies", "ProfileID", "dbo.Profiles", "ProfileID", cascadeDelete: true);
            AddForeignKey("dbo.Hobbies", "TitleID", "dbo.Titles", "TitleID", cascadeDelete: true);
        }
    }
}
