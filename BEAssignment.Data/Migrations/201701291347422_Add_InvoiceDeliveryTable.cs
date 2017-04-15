namespace BEAssignment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_InvoiceDeliveryTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoice", "AddressId", "dbo.Address");
            DropIndex("dbo.Invoice", new[] { "AddressId" });
            CreateTable(
                "dbo.InvoiceDelivery",
                c => new
                    {
                        InvoiceDeliveryId = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceDeliveryId)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId)
                .Index(t => t.InvoiceId)
                .Index(t => t.AddressId);
            
            AddColumn("dbo.Invoice", "Shop", c => c.String());
            AlterColumn("dbo.Invoice", "VatAmount", c => c.Double(nullable: false));
            DropColumn("dbo.Invoice", "AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoice", "AddressId", c => c.Int(nullable: false));
            DropForeignKey("dbo.InvoiceDelivery", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.InvoiceDelivery", "AddressId", "dbo.Address");
            DropIndex("dbo.InvoiceDelivery", new[] { "AddressId" });
            DropIndex("dbo.InvoiceDelivery", new[] { "InvoiceId" });
            AlterColumn("dbo.Invoice", "VatAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Invoice", "Shop");
            DropTable("dbo.InvoiceDelivery");
            CreateIndex("dbo.Invoice", "AddressId");
            AddForeignKey("dbo.Invoice", "AddressId", "dbo.Address", "AddressId");
        }
    }
}
