using System;
using System.Threading.Tasks;
using ErtanSahin.Web.Command.Request;
using ErtanSahin.Web.Data.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ErtanSahin.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateReservationRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("rooms")]
        public async Task<IActionResult> Rooms()
        {
            var response = await _mediator.Send(new GetRoomFilterRequest());
            return Ok(response);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> ListOfReservationFilter([FromQuery]string roomNumber)
        {
            var response = await _mediator.Send(new GetReservationFilterRequest()
            {
                RoomNumber = roomNumber
            });
            return Ok(response);
        }

    }
}