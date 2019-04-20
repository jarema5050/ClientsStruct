namespace ClientsStruct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNiptoCustomerAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAccounts", "Nip", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerAccounts", "Nip");
        }
    }
}
