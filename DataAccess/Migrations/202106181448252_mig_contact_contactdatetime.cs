namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contact_contactdatetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactDateTime");
        }
    }
}
