using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website.Models.Repositories;
using Website.ViewModels;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Website.Models.Repositories;
using Website.Models;

namespace Website.Controllers
{
    public class OrderController : Controller
    {
        private readonly IShopRepositpry<Order> orderRepository;
        private readonly IShopRepositpry<Customer> customerRepository;

        public OrderController(IShopRepositpry<Order> orderRepository, IShopRepositpry<Customer> customerRepository)  //injection object repository
        {
            this.orderRepository = orderRepository;
            this.customerRepository = customerRepository;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            var orders = orderRepository.List();
            return View(orders);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var orders = orderRepository.Find(id);

            return View(orders);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            var model = new OrderCustomerViewModel
            {
                Customers = FillSelectList()
            };

            return View(model);
        } //Form and create model that display customers info

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCustomerViewModel model)
        {
            if (ModelState.IsValid) //validate input frmo user
            {
                try
                {
                    if (model.CustomerId == -1)
                    {//here we will make the message to take value
                        ViewBag.Message = " Please select a customer from the list!"; //Dynamic prop ViewBage allow us to send data from controlller and view
                        //var vmodel = new OrderCustomerViewModel
                        //{
                        //    Customers = FillSelectList()
                        //};
                        return View(GetAllCustomer());
                    };


                    Order order = new Order
                    {

                        Id = model.OrderId,
                        status = model.status,
                        Customer = customerRepository.Find(model.CustomerId),
                    };

                    orderRepository.Add(order);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }

            }
            //var vvmodel = new OrderCustomerViewModel
            //{
            //    Customers = FillSelectList()
            //};
            ModelState.AddModelError("", "You have to fill all the required field");
            return View(GetAllCustomer());
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            var order = orderRepository.Find(id);
            var customerId = order.Customer == null ? order.Customer.Id = 0 : order.Customer.Id;

            var viewModel = new OrderCustomerViewModel
            {
                OrderId = order.Id,
                status = order.status,
                CustomerId = customerId,
                Customers = customerRepository.List().ToList(),
            }; 
            return View(viewModel);
        } // display form

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderCustomerViewModel model) //ppost after save edit form 
        {
            try
            {
                Order order = new Order
                {
                    status = model.status,
                    Customer = customerRepository.Find(model.CustomerId),
                };

                orderRepository.Update(model.OrderId, order);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            var order = orderRepository.Find(id);

            return View(order);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id, Order order)
        {
            try
            {
                orderRepository.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        List<Customer> FillSelectList()
        { //List of Customer, and then we can validate inertion of customer
            var customers = customerRepository.List().ToList();
            customers.Insert(0, new Customer { Id = -1, FullName = "Please select a customer" });
            return customers;
        }

        OrderCustomerViewModel GetAllCustomer()
        {
            var vmodel = new OrderCustomerViewModel
            {
                Customers = FillSelectList(),
            };
            return vmodel;
        }
    }
}