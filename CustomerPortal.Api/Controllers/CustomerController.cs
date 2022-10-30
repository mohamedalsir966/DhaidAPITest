using CustomerPortal.Domain.Entities;
using CustomerPortal.Service.CustomerFeaturs.Commands;
using CustomerPortal.Service.CustomerFeaturs.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPortal.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    //[Authorize]
    public class CustomerController : BaseController
    {
        /// <summary>
        /// add Vaccin  
        /// </summary>
        /// <param name=command></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCustomer(CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// get Customer  by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            return Ok(await Mediator.Send(new GetCustomerByIdQuery { VaccinId = id }));
        }
        /// <summary>
        /// list of Customer
        /// </summary>
        ///  /// <param name="qurey"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCustomers([FromQuery] QueryStringParameters qurey)
        {
            var requst = new GetAllCustomersQuery { Qury = qurey };
            var result = await Mediator.Send(requst);
            return Ok(result);
        }
        /// <summary>
        /// dlete Customer based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {

            var requst = new DeleteCustomerCommand { Id = id };
            var result = await Mediator.Send(requst);
            return Ok(result);
        }
        /// <summary>
        /// Updates Customer based on Id.   
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// 
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }


    }
}
