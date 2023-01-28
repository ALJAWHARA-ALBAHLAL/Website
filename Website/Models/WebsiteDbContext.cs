using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Website.Models;

namespace Website.Models
{
    //This context class typically includes DbSet<TEntity> properties for each entity in the model
    public class WebsiteDbContext : DbContext
    {
        //DbContextOptions manage connection
        // It is the connection between our entity classes and the database.
        // The DBContext is responsible for the database interactions like querying the database and loading the data into memory as entity.
        public WebsiteDbContext(DbContextOptions<WebsiteDbContext> options) : base(options)
        {
        }
        //our tables
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}