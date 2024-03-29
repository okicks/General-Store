namespace GeneralStore.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AUG28_NewCustomerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                {
                    CustomerId = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false),
                    LastName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.CustomerId);

        }

        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
