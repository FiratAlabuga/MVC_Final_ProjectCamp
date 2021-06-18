namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_for_contentdatetype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "ContentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "ContentDate", c => c.String());
        }
    }
}
