namespace Exercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayDateData : DbMigration
    {
        public override void Up()
        {
            Sql("update dbo.Customers set BirthdayDate = '2018/06/16' where id = 3 ");
        }
        
        public override void Down()
        {
        }
    }
}
