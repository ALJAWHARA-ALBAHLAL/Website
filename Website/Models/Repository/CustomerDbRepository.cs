using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using Website.Models.Repositories;

namespace Website.Models.Repository
{
    public class CustomerDbRepository : IShopRepositpry<Customer>
    {
        WebsiteDbContext db; // As context database       

        public CustomerDbRepository(WebsiteDbContext _db)
        {
            db = _db;

            /* customers = new List<Customer>()
              {
                  new Customer()
                  {
                      Id= 1,
                      FullName="Aljawhara"
                  },
                   new Customer()
                  {
                      Id= 2,
                      FullName="Lujain"
                  }
              };*/
        }

        public void Add(Customer entinty)
        {
            //entinty.Id = customers.Max(o => o.Id) + 1;
            db.Customer.Add(entinty);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var customer = db.Customer.SingleOrDefault(x => x.Id == id);
            db.Customer.Remove(customer);
            db.SaveChanges();
        }

        public Customer Find(int id)
        {
            var Customer = db.Customer.SingleOrDefault(x => x.Id == id);
            return Customer;
        }

        public IList<Customer> List()
        {
            return db.Customer.ToList();
        }

        public void Update(int id, Customer newCustomer)
        {
            //var customer = db.Customer.SingleOrDefault(x => x.Id == id);
            //customer.FullName = newCustomer.FullName;
            db.Update(newCustomer);
            db.SaveChanges();
        }
    }
}
