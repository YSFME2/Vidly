namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "GenreID", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreID");
            AddForeignKey("dbo.Movies", "GenreID", "dbo.Genres", "Id", cascadeDelete: true);
            
            //adding genres
            Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Name) VALUES ('Family')");
            Sql("INSERT INTO Genres (Name) VALUES ('Romance')");

            //adding movies
            Sql("INSERT INTO Movies (Name,ReleaseDate,AddedDate,NumberInStock,GenreID) VALUES " +
                $"('Hangover','{DateTime.Now.ToString("yyyy-MM-dd")}','{DateTime.Now.ToString("yyyy-MM-dd")}',5,2)");
            Sql("INSERT INTO Movies (Name,ReleaseDate,AddedDate,NumberInStock,GenreID) VALUES " +
                $"('Die Hard','{DateTime.Now.ToString("yyyy-MM-dd")}','{DateTime.Now.ToString("yyyy-MM-dd")}',3,1)");
            Sql("INSERT INTO Movies (Name,ReleaseDate,AddedDate,NumberInStock,GenreID) VALUES " +
                $"('The Terminator','{DateTime.Now.ToString("yyyy-MM-dd")}','{DateTime.Now.ToString("yyyy-MM-dd")}',7,1)");
            Sql("INSERT INTO Movies (Name,ReleaseDate,AddedDate,NumberInStock,GenreID) VALUES " +
                $"('Toy Story','{DateTime.Now.ToString("yyyy-MM-dd")}','{DateTime.Now.ToString("yyyy-MM-dd")}',3,3)");
            Sql("INSERT INTO Movies (Name,ReleaseDate,AddedDate,NumberInStock,GenreID) VALUES " +
                $"('Titanic','{DateTime.Now.ToString("yyyy-MM-dd")}','{DateTime.Now.ToString("yyyy-MM-dd")}',5,4)");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreID", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreID" });
            DropColumn("dbo.Movies", "GenreID");
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "AddedDate");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropTable("dbo.Genres");
        }
    }
}
