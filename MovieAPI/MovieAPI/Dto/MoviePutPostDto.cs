using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Dto
{
    public class MoviePutPostDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(120)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public List<Actor> Actors { get; set; }
    }
}
