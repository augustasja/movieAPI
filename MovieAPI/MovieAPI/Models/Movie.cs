using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
        [Required]
        public int GenreId { get; set; }
        // Navigation reference
        public Genre MovieGenre { get; set; }

        // ER relationship
        public List<Actor> Actors { get; set; }
    }
}
