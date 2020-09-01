namespace C19OfficeTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrationAfterBuildingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Building",
                c => new
                    {
                        BuildingId = c.Int(nullable: false, identity: true),
                        BuildingName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Postal = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BuildingId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(nullable: false),
                        BuildingId = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        Room = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DeptId)
                .ForeignKey("dbo.Building", t => t.BuildingId, cascadeDelete: false)
                .Index(t => t.BuildingId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        HireDate = c.DateTime(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        TypeOfPosition = c.Int(nullable: false),
                        DeptId = c.Int(nullable: false),
                        IndividualId = c.Guid(nullable: false),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmpId)
                .ForeignKey("dbo.Department", t => t.DeptId, cascadeDelete: false)
                .Index(t => t.DeptId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Tracking",
                c => new
                    {
                        TrackingId = c.Int(nullable: false, identity: true),
                        IndividualId = c.Guid(nullable: false),
                        TrackDate = c.DateTime(nullable: false),
                        SymptomAnswer = c.String(nullable: false, maxLength: 3),
                        ContactAnswer = c.String(nullable: false, maxLength: 3),
                        TempAnswer = c.String(nullable: false, maxLength: 3),
                        Temperature = c.Double(nullable: false),
                        MaskAnswer = c.String(nullable: false, maxLength: 3),
                        GroupAnswer = c.String(nullable: false, maxLength: 3),
                        EmpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrackingId)
                .ForeignKey("dbo.Employee", t => t.EmpId, cascadeDelete: false)
                .Index(t => t.EmpId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        LastLogin = c.DateTime(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Tracking", "EmpId", "dbo.Employee");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Employee", "DeptId", "dbo.Department");
            DropForeignKey("dbo.Department", "BuildingId", "dbo.Building");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Tracking", new[] { "EmpId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Employee", new[] { "DeptId" });
            DropIndex("dbo.Department", new[] { "BuildingId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Tracking");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
            DropTable("dbo.Building");
        }
    }
}
