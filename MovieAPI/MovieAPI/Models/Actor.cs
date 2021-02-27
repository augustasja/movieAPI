using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        // ER relationship
        [JsonIgnore]
        public List<Movie> Movies { get; set; }
    }
}
