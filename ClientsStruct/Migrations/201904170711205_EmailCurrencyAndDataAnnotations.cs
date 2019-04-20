namespace ClientsStruct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailCurrencyAndDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyAccounts", "IsThisEmailCurrent", c => c.Boolean(nullable: false));
            AddColumn("dbo.CustomerAccounts", "IsThisEmailCurrent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerAccounts", "IsThisEmailCurrent");
            DropColumn("dbo.CompanyAccounts", "IsThisEmailCurrent");
        }
    }
}
