namespace ClientsStruct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyAccounts", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyAccounts", "Address");
        }
    }
}
