using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Dto
{
    public class ActorGetDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
    }
}
