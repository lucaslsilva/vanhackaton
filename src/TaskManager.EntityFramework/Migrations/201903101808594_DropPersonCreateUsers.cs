namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropPersonCreateUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Issues", "FK_dbo.Issues_dbo.People_AssigneeId");
            DropForeignKey("dbo.Issues", "FK_dbo.Issues_dbo.People_CreatedById");
            DropIndex("dbo.Issues", new[] { "AssigneeId" });
            DropIndex("dbo.Issues", new[] { "CreatedById" });
            AlterColumn("dbo.Issues", "AssigneeId", c => c.Long(nullable: false));
            AlterColumn("dbo.Issues", "CreatedById", c => c.Long(nullable: false));
            CreateIndex("dbo.Issues", "AssigneeId");
            CreateIndex("dbo.Issues", "CreatedById");
            DropTable("dbo.People");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.Issues", new[] { "CreatedById" });
            DropIndex("dbo.Issues", new[] { "AssigneeId" });
            AlterColumn("dbo.Issues", "CreatedById", c => c.Int(nullable: false));
            AlterColumn("dbo.Issues", "AssigneeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Issues", "CreatedById");
            CreateIndex("dbo.Issues", "AssigneeId");
        }
    }
}
