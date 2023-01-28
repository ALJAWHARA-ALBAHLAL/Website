using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website.Models;
using Website.Models.Repositories;

namespace Website.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IShopRepositpry<Customer> customerRepository;

        public CustomerController(IShopRepositpry<Customer> customerRepository)
        { //Dependncy injection  // handel with interface and change  in startup if we need to change to other Repository
            this.customerRepository = customerRepository;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            var customers = customerRepository.List();
            return View(customers);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var customers = customerRepository.Find(id);
            return View(customers);
        }

        // GET: CustomerController/Create
        public ActionResult Create()//form
        {

            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)//submit
        {
            try
            {
                customerRepository.Add(customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var customers = customerRepository.Find(id);

            return View(customers);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer, int id)
        {
            try
            {
                customerRepository.Update(id, customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = customerRepository.Find(id);

            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {

                customerRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

