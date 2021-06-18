namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_jobtitle_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterJobTitle", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterJobTitle");
        }
    }
}
