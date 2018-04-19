namespace Exercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreModelData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (GenreType) VALUES ('GenreType1')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('GenreType2')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('GenreType3')");
            Sql("INSERT INTO Genres (GenreType) VALUES ('GenreType4')");
        }
        
        public override void Down()
        {
        }
    }
}
