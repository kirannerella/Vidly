using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name= "Customer 2" }
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if(movie.Id==0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStocks = movie.NumberInStocks;
                movieInDb.Genre = movie.Genre;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new MoviesFormViewModel
            {
                Genres = genre
            };
            return View("MovieForm",viewModel);
        }
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if(movie==null)
            {
                return HttpNotFound();
            }
            var viewModel = new MoviesFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }
        
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m=>m.Genre).Where(m => m.Id == id).SingleOrDefault();
            return View(movie);
        }
    }
}