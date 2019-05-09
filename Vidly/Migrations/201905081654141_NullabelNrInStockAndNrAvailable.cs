namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullabelNrInStockAndNrAvailable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "NrAvailable", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "NrAvailable", c => c.Byte(nullable: false));
        }
    }
}
