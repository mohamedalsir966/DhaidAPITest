using Inspector.Domain.Helpers;
using Inspector.Service.InspectorFeaturs.Commands;
using Inspector.Service.InspectorFeaturs.Queries;
using Inspector.Service.ShiftFeaturs.Commands;
using Inspector.Service.ShiftFeaturs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inspector.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShiftController : BaseController
    {


        /// <summary>
        /// for adding new Inspector
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Create(CreateShiftServiceCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// list of Inspector
        /// </summary>
        ///  /// <param name="qurey"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll([FromQuery] QueryStringParameters qurey)
        {
            var requst = new GetAllShiftQuery { Qury = qurey };
            var result = await Mediator.Send(requst);

            return Ok(result);
        }

        /// <summary>
        /// get Inspector  by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var requst = new GetShiftByIdQuery { Id = id };
            var result = await Mediator.Send(requst);
            return Ok(result);
        }


        /// <summary>
        /// delte Inspector  by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var requst = new DeleteShiftServiceByIdCommand { Id = id };
            var result = await Mediator.Send(requst);
            return Ok(result);
        }

        /// <summary>
        /// Updates the  Inspector based on Id.   
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// 
        [HttpPut]
        public async Task<IActionResult> Update(UpdateShiftServiceCommandHanelar command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}
