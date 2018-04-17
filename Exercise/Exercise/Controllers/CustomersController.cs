using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercise.Models;
using System.Data.Entity;
using Exercise.ViewModels;

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
            var viewModel = new CustomerFormViewModel
            {
                MemberShipTypes = memberShipTypes
            };
            return View("CustomerForm",viewModel);
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

        [HttpPost]
        public ActionResult Save(Customers customers)
        {
            if (customers.Id == 0)
            {
                _context.Customers.Add(customers);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customers.Id);

                //AutoMapper 的類別庫 需再Nuget下載
                //Mapper.Map(customer,customerInDb)

                customerInDb.Name = customers.Name;
                customerInDb.BirthdayDate = customers.BirthdayDate;
                customerInDb.MemberShipTypeId = customers.MemberShipTypeId;
                customerInDb.IsSubscribedToNewsletter = customers.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var custumers = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (custumers == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new CustomerFormViewModel
            {
                Customers = custumers,
                MemberShipTypes = _context.MemberShiptypes.ToList()
            };
            return View("CustomerForm",viewmodel);
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