using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientsStruct.Models
{
    public class CustomerAccount
    {
        public string Email { get; set; }
        public bool IsThisEmailCurrent { get; set; }
        public string Login { get; set; }
        public int Id { get; set; }
        public string Address { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public string Nip { get; set; }
    }
}