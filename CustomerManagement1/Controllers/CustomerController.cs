using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerManagement1.Database;
using CustomerManagement1.Models;

namespace CustomerManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext CustomerDbContext;
        public CustomerController(CustomerDbContext customerDbcontext)
        {
            this.CustomerDbContext = customerDbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var Customer = await CustomerDbContext.Customer.ToListAsync();
            return Ok(Customer);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomers([FromBody] Customers cus)
        {
            cus.CustomerId = new Guid();
            await CustomerDbContext.Customer.AddAsync(cus);
            await CustomerDbContext.SaveChangesAsync();

            return Ok(cus);
        }
        [HttpPut]
        [Route("{customerId:guid}")]
        public async Task<IActionResult> updateCustomers([FromRoute] Guid customerId, [FromBody] Customers cus)
        {
            var customers = await CustomerDbContext.Customer.FirstOrDefaultAsync(a => a.CustomerId == customerId);
            if (customers  != null)
            {
                customers.CustomerName = cus.CustomerName;
                customers.Address = cus.Address;
                customers.product = cus.product;
                
                customers.price = cus.price;
              
                await CustomerDbContext.SaveChangesAsync();
                return Ok(cus);
            }
            else
            {
                return NotFound("Customer not found");
            }


        }
        [HttpDelete]
        [Route("{customerId:guid}")]
        public async Task<IActionResult> DeleteCustomers([FromRoute] Guid customerId)
        {
            var customers = await CustomerDbContext.Customer.FirstOrDefaultAsync(a => a.CustomerId == customerId);
            if (customers != null)
            {
                CustomerDbContext.Customer.Remove(customers);
                await CustomerDbContext.SaveChangesAsync();
                return Ok(customers);
            }
            else
            {
                return NotFound("Customer not found");
            }
        }
    }
}
