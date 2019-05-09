namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "NrAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "NrAvailable", c => c.Byte(nullable: false));
        }
    }
}
