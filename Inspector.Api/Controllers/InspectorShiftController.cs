using Inspector.Domain.Helpers;
using Inspector.Service.InspectorShiftFeaturs.Commands;
using Inspector.Service.InspectorShiftFeaturs.Queries;
using Inspector.Service.ShiftFeaturs.Commands;
using Inspector.Service.ShiftFeaturs.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Inspector.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InspectorShiftController : BaseController
    {


        /// <summary>
        /// for ShiftAssignments
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Create(CreateInspectorShiftServiceCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// list of Inspector with his Shifts
        /// </summary>
        ///  /// <param name="qurey"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll([FromQuery] QueryStringParameters qurey)
        {
            var requst = new GetAllInspectorShiftQuery { Qury = qurey };
            var result = await Mediator.Send(requst);

            return Ok(result);
        }

      

    }
}
