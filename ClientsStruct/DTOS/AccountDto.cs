using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientsStruct.DTOS
{
    public class AccountDto
    {
        public string Nip { get; set; }
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Login { get; set; }
        public int Id { get; set; }
        public int CompanyId { get; set; }
    }
}