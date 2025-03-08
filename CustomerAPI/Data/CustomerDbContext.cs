using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CustomerAPI.Data
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        { }
        public DbSet<Customer>Customers { get; set; }
        }
    }
