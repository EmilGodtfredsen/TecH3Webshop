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
        [Required(ErrorMessage ="Field cannot be empty!")]
        [EmailAddress(ErrorMessage = "Email is not valid!")]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password must be atleast 6 chars long!")]
        public string Password { get; set; }
        [Required]
        [StringLength(32, ErrorMessage = "Firstname cannot be longer than 32 chars!")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(32, ErrorMessage = "Lastname cannot be longet than 32 chars!")]
        public string LastName { get; set; }    
        [Required]
        public int Role { get; set; }

        public Address? Address { get; set; }
    }
}
