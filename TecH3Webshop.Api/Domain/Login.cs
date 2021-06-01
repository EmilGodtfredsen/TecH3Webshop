using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Webshop.Api.Domain
{
    public class Login : BaseModel
    {
        public Login()
        {
            Address = new Address();
        }
        [Required]
        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 chars!")]
        public string Email { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Password cannot be longer than 10 chars!")]
        public string Password { get; set; }
        [Required]
        [StringLength(32, ErrorMessage = "Firstname cannot be longer than 32 chars!")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(32, ErrorMessage = "Lastname cannot be longet than 32 chars!")]
        public string LastName { get; set; }    
        [Required]
        public int Role { get; set; }

        public Address Address { get; set; }
    }
}
