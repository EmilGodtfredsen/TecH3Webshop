using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Webshop.Api.Domain
{
    public class Image : BaseModel
    {
        [ForeignKey("Product.Id")]
        public int ProductId { get; set; }

        [MaxLength(260)]
        public string ImagePath { get; set; }
    }
}
