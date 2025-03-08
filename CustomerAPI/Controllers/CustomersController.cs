using CustomerAPI.Data;
using CustomerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly CustomerDbContext _dbContext;

        public CustomersController(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {

            return await _dbContext.Customers.ToListAsync();

        }
        [HttpGet("id")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            {
                if (customer == null)
                {
                    return NotFound();
                }

                return customer;
            }
        }
    }
}
