using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ClientsStruct.Models
{
    public class CompanyAccount
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsThisEmailCurrent { get; set; }
        public string Email { get; set; } 
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Address { get; set; }
        public string Login { get; set; }
        public int Id { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}