using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Dto
{
    public class ActorPutPostDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        public string FullName { get; set; }
        //public List<Movie> Movies { get; set; }

    }
}
