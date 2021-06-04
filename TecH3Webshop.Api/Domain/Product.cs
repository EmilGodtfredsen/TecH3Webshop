using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Webshop.Api.Domain
{
    public class Product : BaseModel
    {
        public Product()
        {
            Images = new List<Image>();
        }
        [Required]
        [StringLength(32, ErrorMessage = "Product name cannot be longet than 32 chars!")]
        public string Name { get; set; }

        [ForeignKey("Brand.Id")]
        public int BrandId { get; set; }

        [ForeignKey("Category.Id")]
        public int CategoryId { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Category Category { get; set; }

        public Brand Brand { get; set; }

        public List<Image> Images { get; set; }
    }
}
