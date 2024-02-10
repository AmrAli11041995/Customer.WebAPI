using Assets.WebAPI.Controllers;
using Customer.Core.Interfaces.IAppServices;
using Customer.DTOs.AppDTOs.Customer;
using Customer.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Customer.WebAPI.Controllers
{
    [Route("api/" + nameof(Contexts.CustomerAppContext) + "/" + "[controller]")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService )
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries(PaginatedFiltration filtrationDTO)
        {

            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }

            if (ModelState.IsValid)
            {
                return Ok(await _customerService.FilterByAsync(filtrationDTO));
            }

            return BadRequest(ModelState);

        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDTO customerCreateDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }

            if (ModelState.IsValid)
            {

                return Ok(await _customerService.CreateAsync(customerCreateDto));
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDCustomer([FromBody] CustomerUpdateDTO customerUpdateDto)
        {


            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }

            if (ModelState.IsValid)
            {
                return Ok(await _customerService.UpdateAsync(customerUpdateDto));
            }

            return BadRequest(ModelState);

        }

    

        [HttpGet("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }

            if (ModelState.IsValid)
            {
                return Ok(await _customerService.GetByIdAsync(id));
            }

            return BadRequest(ModelState);

        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }

            if (ModelState.IsValid)
            {
                return Ok(await _customerService.DeleteAsync(id));
            }

            return BadRequest(ModelState);

        }
    }
}