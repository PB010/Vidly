namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingNrAvailable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET NrAvailable = NrInStock");
        }
        
        public override void Down()
        {
        }
    }
}
