namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingrental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.MovieID)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "CustomerID" });
            DropIndex("dbo.Rentals", new[] { "MovieID" });
            DropTable("dbo.Rentals");
        }
    }
}
