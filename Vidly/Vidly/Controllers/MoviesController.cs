using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shark" };
            //比較不好的方法
            //ViewData["Movie"] = movie;
            //viewbag也沒比較好
            //##主要是因為 在view 的那端 在接收上 會用@viewbag.Movie 做承接 但如果Controller 這改名 那viewbag 也需要改名這樣不符合效益
            //ViewBag.Movie = movie;
            //所以直接把model 傳進 View method 裡面會是最好
            var customers = new List<Customer>
            {
                new Customer{Name="Customer 1"},
                new Customer{Name="Customer 2"}
            };

            var viewModel = new Vidly.ViewModels.RandomMovieViewModel()
            {
                //前面的Movie 跟 Customers 都是在 RandomMoiveViewModel 裡面的屬性
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index","Home",new {page = 1 , sortby = "name"});
        }
        public ActionResult Edit(int id)
        {
            return Content("id =" + id);
        }
        public ActionResult Index(int? pageIndex , string sortBy)
        {

            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" + month);
        }
    }
}