using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Infrastructure;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Services
{
    public class GenreRepo : BaseRepo<Genre>, IGenreRepo
    {
        public GenreRepo(Context context) : base(context)
        {

        }
    }
}
