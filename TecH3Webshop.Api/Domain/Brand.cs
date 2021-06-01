using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Webshop.Api.Domain
{
    public class Brand : BaseModel
    {
        [Required]
        [StringLength(32, ErrorMessage = "Brand name cannot be longer than 32 chars!")]

        public string Name { get; set; }

        public Product Product { get; set; }
    }
}
