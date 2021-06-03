using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Webshop.Api.Domain
{
    public class Picture : BaseModel
    {
        [MaxLength(260)]
        public string CoverImagePath { get; set; }
    }
}
