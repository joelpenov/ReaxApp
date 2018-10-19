using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ReaxApp.ReaxDbContext;
using ReaxApp.ReaxDbContext.Entities;

namespace ReaxApp.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IReaxDatabaseContext _reaxDatabaseContext;

        public MoviesController(IReaxDatabaseContext reaxDatabaseContext)
        {
            _reaxDatabaseContext = reaxDatabaseContext;
        }

        public IActionResult Get(string search, int pageSize = 10, int pageNumber = 1)
        {
            pageSize = pageSize < 1 ? 10 : pageSize;
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            try
            {
                var movies = _reaxDatabaseContext.Movies.AsQueryable();
                var filteredData = string.IsNullOrWhiteSpace(search)
                    ? movies : movies.Where(c =>
                         c.Title.Contains(search) ||
                         c.Actors.Contains(search) ||
                         c.Rated.Contains(search) ||
                         c.Synopsis.Contains(search) ||
                         c.Year.ToString().Contains(search) ||
                         c.SynopsisEnglish.Contains(search));

                var dataPage = filteredData.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
                return Ok(dataPage);
            }
            catch (Exception e)
            {
                return Content("Error: ", e.Message);
            }
        }

        [HttpGet("{movieId}")]
        public ActionResult<Movie> GetById(int movieId)
        {
            var movie = _reaxDatabaseContext.Movies.FirstOrDefault(x => x.Id == movieId);
            if (movie == null) return NotFound();
            return movie;
        }

        [HttpGet("{originalMovieHash}")]
        public ActionResult<Movie> GetById(string originalMovieHash)
        {
            var movie = _reaxDatabaseContext.Movies.FirstOrDefault(x => x.OriginalId == originalMovieHash);
            if (movie == null) return NotFound();
            return movie;
        }
    }
}
