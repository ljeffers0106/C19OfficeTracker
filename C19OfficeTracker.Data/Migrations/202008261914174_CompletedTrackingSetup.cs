namespace C19OfficeTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompletedTrackingSetup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracking", "IndividualId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tracking", "IndividualId");
        }
    }
}
