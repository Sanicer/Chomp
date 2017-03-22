using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chomp.Dtos
{
    public class CuisineDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}