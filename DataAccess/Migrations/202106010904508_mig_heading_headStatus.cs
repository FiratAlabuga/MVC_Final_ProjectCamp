namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_heading_headStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "HeadStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "HeadStatus");
        }
    }
}
