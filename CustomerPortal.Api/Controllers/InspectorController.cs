using CustomerPortal.Domain.Entities;
using CustomerPortal.Service.InspectorFeaturs.Commands;
using CustomerPortal.Service.InspectorFeaturs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CustomerPortal.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InspectorController : BaseController
    {
        /// <summary>
        /// list of  InspectorsSchedule
        /// </summary>
        ///  /// <param name="qurey"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("/InspectorsSchedule")]
        public async Task<IActionResult> GetAll([FromQuery] QueryStringParameters qurey)
        {
            var requst = new GetInspectorsScheduleQuery { Qury = qurey };
            var result = await Mediator.Send(requst);

            return Ok(result);
        }

        /// <summary>
        /// for adding new  Appointment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost("/Appointment")]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentServiceCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
