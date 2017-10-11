namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeUserId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "User_UserID", "dbo.Users");
            DropIndex("dbo.Photos", new[] { "User_UserID" });
            DropColumn("dbo.Photos", "UserID");
            RenameColumn(table: "dbo.Photos", name: "User_UserID", newName: "UserID");
            AlterColumn("dbo.Photos", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Photos", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Photos", "UserID");
            AddForeignKey("dbo.Photos", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "UserID", "dbo.Users");
            DropIndex("dbo.Photos", new[] { "UserID" });
            AlterColumn("dbo.Photos", "UserID", c => c.Int());
            AlterColumn("dbo.Photos", "UserID", c => c.String());
            RenameColumn(table: "dbo.Photos", name: "UserID", newName: "User_UserID");
            AddColumn("dbo.Photos", "UserID", c => c.String());
            CreateIndex("dbo.Photos", "User_UserID");
            AddForeignKey("dbo.Photos", "User_UserID", "dbo.Users", "UserID");
        }
    }
}
