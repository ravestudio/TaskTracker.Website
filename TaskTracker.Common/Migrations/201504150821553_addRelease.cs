namespace TaskTracker.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRelease : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Releases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Key = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.IssueSet", "Release_Id", c => c.Int());
            AddColumn("dbo.IssueSet", "ReleaseId", c => c.Int());
            CreateIndex("dbo.IssueSet", "Release_Id");
            CreateIndex("dbo.IssueSet", "ReleaseId");
            AddForeignKey("dbo.IssueSet", "Release_Id", "dbo.Releases", "Id");
            AddForeignKey("dbo.IssueSet", "ReleaseId", "dbo.Releases", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssueSet", "ReleaseId", "dbo.Releases");
            DropForeignKey("dbo.IssueSet", "Release_Id", "dbo.Releases");
            DropIndex("dbo.IssueSet", new[] { "ReleaseId" });
            DropIndex("dbo.IssueSet", new[] { "Release_Id" });
            DropColumn("dbo.IssueSet", "ReleaseId");
            DropColumn("dbo.IssueSet", "Release_Id");
            DropTable("dbo.Releases");
        }
    }
}
