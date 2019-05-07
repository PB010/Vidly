namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNrAvailableToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NrAvailable", c => c.Byte(nullable: false));
            Sql("UPDATE Movies SET NrAvailable = NrInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NrAvailable");
        }
    }
}
