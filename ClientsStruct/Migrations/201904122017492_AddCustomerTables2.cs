namespace ClientsStruct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerTables2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Login = c.String(),
                        Address = c.String(),
                        Telephone1 = c.String(),
                        Telephone2 = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerAccounts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerAccounts", new[] { "CustomerId" });
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerAccounts");
        }
    }
}
