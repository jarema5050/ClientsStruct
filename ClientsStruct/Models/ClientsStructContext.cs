using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClientsStruct.Models
{
    public class ClientsStructContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ClientsStructContext() : base("name=ClientsStructContext")
        {
        }

        public System.Data.Entity.DbSet<ClientsStruct.Models.CompanyAccount> CompanyAccounts { get; set; }

        public System.Data.Entity.DbSet<ClientsStruct.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<ClientsStruct.Models.CustomerAccount> CustomerAccounts { get; set; }

        public System.Data.Entity.DbSet<ClientsStruct.Models.Customer> Customers { get; set; }
    }
}
