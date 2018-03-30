namespace Exercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberShipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("Update MemberShipTypes set Name = 'Pay as You Go' where id = 1");
            Sql("Update MemberShipTypes set Name = 'Monthly' where id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
