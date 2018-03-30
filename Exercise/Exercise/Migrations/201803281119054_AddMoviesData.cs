namespace Exercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into dbo.Movies(Name,Genre,ReleaseDate,DateAdded,NumInStock) Values('MoviesName1','Comedy','2014/01/01','2018/03/28',5)");
            Sql("Insert into dbo.Movies(Name,Genre,ReleaseDate,DateAdded,NumInStock) Values('MoviesName2','Comedy','2010/01/01','2016/03/28',5)");
            Sql("Insert into dbo.Movies(Name,Genre,ReleaseDate,DateAdded,NumInStock) Values('MoviesName3','Comedy','2009/01/01','2015/03/28',5)");
        }
        
        public override void Down()
        {
        }
    }
}
