namespace GeneralStore.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AUG28_NewTransactionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                {
                    TransactionId = c.Int(nullable: false, identity: true),
                    CustomerId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "ProductId" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropTable("dbo.Transactions");
        }
    }
}
