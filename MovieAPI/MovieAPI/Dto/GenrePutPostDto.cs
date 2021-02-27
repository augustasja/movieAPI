using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Dto
{
    public class GenrePutPostDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Type { get; set; }
    }
}
