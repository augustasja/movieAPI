using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Type { get; set; }
        [JsonIgnore]
        public ICollection<Movie> Movies { get; set; }
    }
}
