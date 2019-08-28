namespace GeneralStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTransactionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Quantity");
        }
    }
}
