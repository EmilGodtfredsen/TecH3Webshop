using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Webshop.Api.Domain
{
    public class Category : BaseModel
    {
        [Required]
        [StringLength(32, ErrorMessage = "Category name cannot be longet than 32 chars!")]

        public string Name { get; set; }
    }
}
