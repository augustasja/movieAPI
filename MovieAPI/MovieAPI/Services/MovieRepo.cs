using MovieAPI.Data;
using MovieAPI.Infrastructure;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Services
{
    public class MovieRepo : BaseRepo<Movie>, IMovieRepo
    {

        public MovieRepo(Context context) : base(context)
        {

        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.Include(a => a.Actors).Include(g => g.MovieGenre).FirstOrDefaultAsync(i => i.Id == id);
        }

        public override async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.Include(a => a.Actors).Include(g => g.MovieGenre).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> SearchMovieAsync(string searchTerm)
        {
            IQueryable<Movie> query = _context.Movies;
                query = query.Include(a => a.Actors).Where(n => n.Name.Contains(searchTerm) || n.MovieGenre.Type.Contains(searchTerm));
 
            return await query.ToListAsync();
            //return await _context.Movies.Include(g => g.MovieGenre).Where(x => x.Name == searchTerm || x.MovieGenre.Type == searchTerm).ToListAsync();
            
        }
        public async Task<IEnumerable<Movie>> SearchByMovieDateAsync(DateTime releaseDate)
        {
            return await _context.Movies.Include(g => g.MovieGenre)
                                        .Where(x => x.ReleaseDate == releaseDate).ToListAsync();
            
        }
    }
}
