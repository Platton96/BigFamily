namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhotoandnewdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Albom = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                        UserID = c.String(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "User_UserID", "dbo.Users");
            DropIndex("dbo.Photos", new[] { "User_UserID" });
            DropTable("dbo.Photos");
        }
    }
}
