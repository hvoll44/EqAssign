namespace EqAssign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (1, 0, 0, 0, 'Gold')");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (2, 10, 3, 15, 'Bronze')");

            Sql("INSERT INTO ModelTypes (Id, Name) VALUES (1, 'Standard')");
            Sql("INSERT INTO ModelTypes (Id, Name) VALUES (2, 'Premium')");
        }
        
        public override void Down()
        {
        }
    }
}
