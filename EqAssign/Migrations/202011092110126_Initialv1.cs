namespace EqAssign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsSubscribedToNewsLetter = c.Boolean(nullable: false),
                        MembershipTypeId = c.Byte(nullable: false),
                        Birthdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        ModelTypeId = c.Byte(nullable: false),
                        ManufactureDate = c.DateTime(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        Stock = c.Int(nullable: false),
                        Available = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModelTypes", t => t.ModelTypeId, cascadeDelete: true)
                .Index(t => t.ModelTypeId);
            
            CreateTable(
                "dbo.ModelTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_Id = c.Int(nullable: false),
                        Equipment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Equipment_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Equipments", "ModelTypeId", "dbo.ModelTypes");
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Rentals", new[] { "Equipment_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropIndex("dbo.Equipments", new[] { "ModelTypeId" });
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropTable("dbo.Rentals");
            DropTable("dbo.ModelTypes");
            DropTable("dbo.Equipments");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
        }
    }
}
