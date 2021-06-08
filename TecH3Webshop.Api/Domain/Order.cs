using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Webshop.Api.Domain
{
    public class Order : BaseModel
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        [ForeignKey("Login.Id")]
        public int LoginId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } 

        public Login Login { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } 
    }
}
