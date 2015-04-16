namespace TaskTracker.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IssueSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IssueNumber = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Key = c.String(maxLength: 50),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IssueSatusSet", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.IssueSatusSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Key = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssueSet", "StatusId", "dbo.IssueSatusSet");
            DropIndex("dbo.IssueSet", new[] { "StatusId" });
            DropTable("dbo.IssueSatusSet");
            DropTable("dbo.IssueSet");
        }
    }
}
