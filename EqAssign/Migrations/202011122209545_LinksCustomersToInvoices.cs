namespace EqAssign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinksCustomersToInvoices : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Invoices", "CustomerId");
            AddForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Invoices", new[] { "CustomerId" });
        }
    }
}
