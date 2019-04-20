using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientsStruct.DTOS
{
    public class AccountDto
    {
        
        [RegularExpression("([0-9]{3}-[0-9]{3}-[0-9]{2}-[0-9]{2})|([0-9]{3}-[0-9]{2}-[0-9]{2}-[0-9]{3})|([0-9]{10})|([A-Z]{2}[0-9]{10})", ErrorMessage ="Not match to NIP.")]
        public string Nip { get; set; }
        [StringLength(255)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(90)]
        public string Name { get; set; }
        [Required]
        [StringLength(120)]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [RegularExpression("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$")]
        public string Telephone1 { get; set; }
        [Phone]
        [RegularExpression("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$")]
        public string Telephone2 { get; set; }
        [Required]
        [StringLength(20,MinimumLength=3)]
        public string Login { get; set; }
        public string Address { get; set; }
    }
}