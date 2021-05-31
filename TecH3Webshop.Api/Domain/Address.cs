using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Webshop.Api.Domain
{
    public class Address : BaseModel
    {
        [ForeignKey("Login.Id")]
        public int LoginId { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Street cannot be longer than 32 chars!")]
        public string Street { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "House (Number or Floor, door) cannot be longer than 10 chars!")]
        public string House { get; set; }
        [Required]
        [StringLength(32, ErrorMessage = "City cannot be longer than 32 chars!")]
        public string City { get; set; }
        [Required]
        public int Zipcode { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Country cannot be longer than 32 chars!")]
        public string Country { get; set; }
    }
}
