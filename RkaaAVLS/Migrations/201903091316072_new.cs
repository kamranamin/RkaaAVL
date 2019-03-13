namespace RkaaAVLS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MainOrganizations", "UserId", c => c.Int(nullable: true));
            CreateIndex("dbo.MainOrganizations", "UserId");
            AddForeignKey("dbo.MainOrganizations", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MainOrganizations", "UserId", "dbo.Users");
            DropIndex("dbo.MainOrganizations", new[] { "UserId" });
            DropColumn("dbo.MainOrganizations", "UserId");
        }
       
    }
}
