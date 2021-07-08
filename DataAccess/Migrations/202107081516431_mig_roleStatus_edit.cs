namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_roleStatus_edit : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Admins", name: "Roles_RoleId", newName: "RoleId");
            RenameIndex(table: "dbo.Admins", name: "IX_Roles_RoleId", newName: "IX_RoleId");
            AddColumn("dbo.Admins", "AdminName", c => c.String());
            AddColumn("dbo.Admins", "AdminStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminStatus");
            DropColumn("dbo.Admins", "AdminName");
            RenameIndex(table: "dbo.Admins", name: "IX_RoleId", newName: "IX_Roles_RoleId");
            RenameColumn(table: "dbo.Admins", name: "RoleId", newName: "Roles_RoleId");
        }
    }
}
