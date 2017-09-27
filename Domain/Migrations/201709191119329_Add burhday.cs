namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addburhday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Burthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Burthday");
        }
    }
}
