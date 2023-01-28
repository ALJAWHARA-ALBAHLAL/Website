using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Models.Repositories;
using Website.Models;

namespace Website.Models.Repositories
{
    public class OrderRepository : IShopRepositpry<Order>
    {
        List<Order> orders; // As context database   //We can replace it with EF

        public OrderRepository()
        {
            orders = new List<Order>()
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
             };
        }

        public void Add(Order entinty)
        {
            entinty.Id = orders.Max(o => o.Id) + 1;
            orders.Add(entinty);
        }

        public void Delete(int id)
        {
            var book = orders.SingleOrDefault(x => x.Id == id);
            orders.Remove(book);
        }

        public Order Find(int id)
        {
            var order = orders.SingleOrDefault(x => x.Id == id);
            return order;
        }

        public IList<Order> List()
        {
            return orders;
        }

        public void Update(int id, Order newOrder)
        {
            var order = orders.SingleOrDefault(x => x.Id == id);
            order.status = newOrder.status;
            order.Customer = newOrder.Customer;

        }


    }
}
