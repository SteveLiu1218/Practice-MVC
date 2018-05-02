using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercise.Models;
using System.Data.Entity;

namespace Exercise.Controllers
{
    public class MoviesController : Controller
    {
        //要用Entity就要呼叫出DbContext
        private ApplicationDbContext _context;
        // GET: Movies
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            //var movies = GetMovies();
            var movies = _context.Movies.Include(c => c.Genres).ToList();
            return View(movies);
        }
        public ViewResult MovieDetails(int? id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);
            return View(movies);
        }

        //新增電影區塊
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ViewModels.NewMoviesViewModel(movie)
                {
                    Genre = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            //新增
            if (movie.Id == 0)
            {                
                movie.DateAdded = DateTime.Now;                
                _context.Movies.Add(movie);
            }
            //修改
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumInStock = movie.NumInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;                
            }
            try
            {
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult EditMovie(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            var viewModel = new ViewModels.NewMoviesViewModel(movies)
            {
                Genre = _context.Genres.ToList()
            };

            return View("MoviesForm", movies);
        }
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new ViewModels.NewMoviesViewModel
            {
                Genre = genres                
            };

            return View("MovieForm", viewModel);
        }

    }
}