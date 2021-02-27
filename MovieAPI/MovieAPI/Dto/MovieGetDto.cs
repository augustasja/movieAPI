using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Dto
{
    public class MovieGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string GenreName { get; set; }
        //public int GenreId { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
