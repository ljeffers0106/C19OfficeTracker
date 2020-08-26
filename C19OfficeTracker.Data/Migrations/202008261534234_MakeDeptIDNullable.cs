namespace C19OfficeTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDeptIDNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "DeptId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DeptId" });
            AlterColumn("dbo.Employee", "DeptId", c => c.Int());
            CreateIndex("dbo.Employee", "DeptId");
            AddForeignKey("dbo.Employee", "DeptId", "dbo.Department", "DeptId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "DeptId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DeptId" });
            AlterColumn("dbo.Employee", "DeptId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employee", "DeptId");
            AddForeignKey("dbo.Employee", "DeptId", "dbo.Department", "DeptId", cascadeDelete: true);
        }
    }
}
