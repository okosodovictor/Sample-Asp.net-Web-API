namespace BEAssignment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestructureEntitiesScehema : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoice", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.InvoiceDelivery", "AddressId", "dbo.Address");
            DropForeignKey("dbo.InvoiceDelivery", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.Address", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Invoice", new[] { "CustomerId" });
            DropIndex("dbo.InvoiceDelivery", new[] { "InvoiceId" });
            DropIndex("dbo.InvoiceDelivery", new[] { "AddressId" });
            AddColumn("dbo.Invoice", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoice", "AddressId");
            AddForeignKey("dbo.Invoice", "AddressId", "dbo.Address", "AddressId", cascadeDelete: true);
            AddForeignKey("dbo.Address", "CustomerID", "dbo.Customer", "CustomerId", cascadeDelete: true);
            DropColumn("dbo.Invoice", "CustomerId");
            DropTable("dbo.InvoiceDelivery");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InvoiceDelivery",
                c => new
                    {
                        InvoiceDeliveryId = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceDeliveryId);
            
            AddColumn("dbo.Invoice", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Address", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Invoice", "AddressId", "dbo.Address");
            DropIndex("dbo.Invoice", new[] { "AddressId" });
            DropColumn("dbo.Invoice", "AddressId");
            CreateIndex("dbo.InvoiceDelivery", "AddressId");
            CreateIndex("dbo.InvoiceDelivery", "InvoiceId");
            CreateIndex("dbo.Invoice", "CustomerId");
            AddForeignKey("dbo.Address", "CustomerID", "dbo.Customer", "CustomerId");
            AddForeignKey("dbo.InvoiceDelivery", "InvoiceId", "dbo.Invoice", "InvoiceId");
            AddForeignKey("dbo.InvoiceDelivery", "AddressId", "dbo.Address", "AddressId");
            AddForeignKey("dbo.Invoice", "CustomerId", "dbo.Customer", "CustomerId");
        }
    }
}
