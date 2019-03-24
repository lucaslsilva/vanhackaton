namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitiesCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        Deadline = c.DateTime(nullable: false),
                        Status = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        AssigneeId = c.Int(nullable: false),
                        CreatedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.AssigneeId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.CreatedById)
                .Index(t => t.AssigneeId)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "CreatedById", "dbo.People");
            DropForeignKey("dbo.Issues", "AssigneeId", "dbo.People");
            DropIndex("dbo.Issues", new[] { "CreatedById" });
            DropIndex("dbo.Issues", new[] { "AssigneeId" });
            DropTable("dbo.People");
            DropTable("dbo.Issues");
        }
    }
}
