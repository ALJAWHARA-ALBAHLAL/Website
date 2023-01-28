using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using Website.Models.Repositories;
using Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Website.Models.Repository
{
    public class OrderDbRepository : IShopRepositpry<Order>
    {
        // List<Order> orders; // As context database   //We can replace it with EF
        WebsiteDbContext db;

        public OrderDbRepository(WebsiteDbContext _db)
        {
            db = _db;
            /*orders = new List<Order>()
             {
                 new ()
                 {
                     Id= 1,
                     status="completed",
                     Customer = new Customer{
                         Id = 1,
                         FullName ="Aljawhara" }
                 },
                  new Order()
                 {
                     Id= 2,
                     status="pending",
                     Customer = new Customer{
                         Id = 2,
                         FullName ="Lujain" }
                 }
             };*/
        }

        public void Add(Order entinty)
        {
            //entinty.Id = orders.Max(o => o.Id) + 1;
            db.Order.Add(entinty);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var book = db.Order.SingleOrDefault(x => x.Id == id);
            db.Order.Remove(book);
            db.SaveChanges();

        }

        public Order Find(int id)
        {
            var order = db.Order.Include(a => a.Customer).SingleOrDefault(x => x.Id == id);
            return order;
        }

        public IList<Order> List()
        {
            return db.Order.Include(a => a.Customer).ToList();
        }

        public void Update(int id, Order newOrder)
        {
            db.Update(newOrder);
            db.SaveChanges();
            //var order = orders.SingleOrDefault(x => x.Id == id);
            //order.status = newOrder.status;
            //order.Customer = newOrder.Customer;
        }
    }
}




