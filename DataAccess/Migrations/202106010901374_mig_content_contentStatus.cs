﻿namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_content_contentStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "ContentStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "ContentStatus");
        }
    }
}
