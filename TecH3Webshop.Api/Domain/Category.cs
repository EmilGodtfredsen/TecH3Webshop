using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Webshop.Api.Domain
{
    public class Category : BaseModel
    {
        public Category()
        {
            Products = new List<Product>();
        }
        [Required]
        [StringLength(32, ErrorMessage = "Category name cannot be longet than 32 chars!")]

        public string Name { get; set; }

        public List<Product> Products { get; set; }




    }
}
