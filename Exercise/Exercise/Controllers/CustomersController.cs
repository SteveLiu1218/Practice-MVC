using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercise.Models;
using System.Data.Entity;

namespace Exercise.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var memberShipTypes = _context.MemberShiptypes.ToList();
            var viewModel = new Exercise.ViewModels.NewCustomerViewModel
            {
                MemberShipTypes = memberShipTypes
            };
            return View(viewModel);
        }
        public ViewResult Index()
        {
            //var customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }
        //### 用Route控制 也可以 當然也用原本的 action 也就是 method方法名稱來做網址區隔
        //但如果用Route 要記得 routeConfig 的 routes.MapMvcAttributeRoutes(); 要加上
        //[Route("customer11/details/{id}")]
        public ActionResult Details(int id)
        {
            //###這段要查是甚麼意思 
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        //private IEnumerable<Customers> GetCustomers()
        //{
        //    return new List<Customers>
        //    {
        //        new Customers{Id = 1 , Name = "John Customers 1"},
        //        new Customers{Id = 2 , Name = "Mary Customers 2"}
        //    };
        //}
    }
}