using CustomerAPI.Data;
using CustomerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route("api / [controller]")]
    public class CustomersController : Controller
    {
        private readonly CustomerDbContext _dbContext;

        public CustomersController(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers() {
         
            var customers= await _dbContext.Customers.Select(c=>new CustomerDTO
            {
                CustomerId = c.CustomerId,
                FirstName=c.FirstName,
                LastName=c.LastName,
                Email=c.Email,
                PhoneNumber=c.PhoneNumber,
            }).ToListAsync();
            
            return customers;
        }
    }
}
