namespace Exercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopularMemberShipTypes : DbMigration
    {
        public override void Up()
        {
            //MemberShipTypes 有ID的欄位 因為是 Key 會自己加 所以不用填入
            Sql("INSERT INTO MemberShipTypes (SignUpFee,DurationInMonths,DiscountRate) VALUES (0,0,0)");
            Sql("INSERT INTO MemberShipTypes (SignUpFee,DurationInMonths,DiscountRate) VALUES (30,1,10)");
            Sql("INSERT INTO MemberShipTypes (SignUpFee,DurationInMonths,DiscountRate) VALUES (90,3,15)");
            Sql("INSERT INTO MemberShipTypes (SignUpFee,DurationInMonths,DiscountRate) VALUES (300,12,20)");
            
        }
        
        public override void Down()
        {
        }
    }
}
