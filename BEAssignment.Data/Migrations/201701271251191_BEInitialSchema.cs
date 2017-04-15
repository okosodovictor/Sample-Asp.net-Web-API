namespace BEAssignment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BEInitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        AddressName = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Customer", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        InvoiceType = c.String(),
                        invoiceTypeLocalized = c.String(),
                        InvoiceDate = c.DateTime(),
                        PaymentDueDate = c.DateTime(),
                        InvoiceNumber = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        PeriodDescription = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VatAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoice", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Invoice", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Address", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Invoice", new[] { "AddressId" });
            DropIndex("dbo.Invoice", new[] { "CustomerId" });
            DropIndex("dbo.Address", new[] { "CustomerID" });
            DropTable("dbo.Invoice");
            DropTable("dbo.Customer");
            DropTable("dbo.Address");
        }
    }
}
