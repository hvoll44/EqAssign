namespace EqAssign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinksEquipmentToInvoices : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Invoices", "EquipmentId");
            AddForeignKey("dbo.Invoices", "EquipmentId", "dbo.Equipments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "EquipmentId", "dbo.Equipments");
            DropIndex("dbo.Invoices", new[] { "EquipmentId" });
        }
    }
}
