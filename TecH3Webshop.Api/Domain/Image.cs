using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Webshop.Api.Domain
{
    public class Image : BaseModel
    {
        [MaxLength(260)]
        public string ImagePath { get; set; }
    }
}
