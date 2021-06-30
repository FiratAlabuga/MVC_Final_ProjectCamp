namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adminHashUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary(maxLength: 500));
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary(maxLength: 500));
            AddColumn("dbo.Admins", "AdminName", c => c.Binary(maxLength: 500));
            Sql("Update dbo.Admins SET AdminName = Convert(varbinary, AdminUsername)");
            DropColumn("dbo.Admins", "AdminUsername");
            RenameColumn("dbo.Admins", "AdminName", "AdminUsername");
            DropColumn("dbo.Admins", "AdminPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "AdminUsername", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminPasswordSalt");
            DropColumn("dbo.Admins", "AdminPasswordHash");
        }
    }
}
