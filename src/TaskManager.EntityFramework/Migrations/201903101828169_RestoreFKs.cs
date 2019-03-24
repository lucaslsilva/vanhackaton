namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoreFKs : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Issues", "AssigneeId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Issues", "CreatedById", "dbo.AbpUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "CreatedById", "dbo.AbpUsers");
            DropForeignKey("dbo.Issues", "AssigneeId", "dbo.AbpUsers");
            DropIndex("dbo.Issues", new[] { "CreatedById" });
            DropIndex("dbo.Issues", new[] { "AssigneeId" });
        }
    }
}
