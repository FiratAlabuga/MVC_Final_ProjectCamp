namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_for_writer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 150));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 150));
            AlterColumn("dbo.Writers", "WriterPass", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterPass", c => c.String(maxLength: 20));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "WriterAbout");
        }
    }
}
