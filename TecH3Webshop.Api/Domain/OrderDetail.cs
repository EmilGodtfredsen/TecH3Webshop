using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Webshop.Api.Domain
{
    public class OrderDetail : BaseModel
    {
        [ForeignKey("Order.Id")]
        public int OrderId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }

        [ForeignKey("Product.Id")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
