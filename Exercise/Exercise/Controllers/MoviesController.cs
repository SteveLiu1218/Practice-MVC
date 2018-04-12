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
            var movies = _context.Movies.ToList();
            return View(movies);
        }
        public ViewResult MovieDetails(int? id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);
            return View(movies);
        }
    }
}