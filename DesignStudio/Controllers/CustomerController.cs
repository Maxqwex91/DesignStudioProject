using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Output;
using Services.Interfaces;

namespace DesignStudio.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("customers-social-networks")]
        public async Task<ActionResult<List<CustomerSocialNetworksDTO>>> GetCustomersWithSocialNetworksAsync(CancellationToken cancellationToken) 
        {
            var customers = await _customerService.GetCustomersWithSocialNetworksAsync(cancellationToken);
            return Ok(customers);
        }

        [HttpGet("{id}/customer-working-hours")]
        public async Task<ActionResult<double>> GetCustomerWorkingHoursByCustomerIdAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await _customerService.GetWorkingHoursByCustomerId(id, cancellationToken);
            return Ok(result);
        }
    }
}
