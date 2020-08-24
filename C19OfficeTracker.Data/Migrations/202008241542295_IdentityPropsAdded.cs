namespace C19OfficeTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityPropsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "FullName", c => c.String());
            AddColumn("dbo.ApplicationUser", "LastLogin", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "LastLogin");
            DropColumn("dbo.ApplicationUser", "FullName");
        }
    }
}
