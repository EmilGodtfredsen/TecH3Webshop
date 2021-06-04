using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Webshop.Api.Domain
{
    public class Brand : BaseModel
    {
        public Brand()
        {
            Products = new List<Product>();
        }
        [Required]
        [StringLength(32, ErrorMessage = "Brand name cannot be longer than 32 chars!")]

        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
