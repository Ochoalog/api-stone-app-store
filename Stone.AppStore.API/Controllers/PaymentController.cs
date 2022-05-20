using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stone.AppStore.Application.Commands.PaymentCommands;
using Stone.AppStore.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Stone.AppStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> Post([FromBody] PaymentCommand paymentCommand)
        {
            return Ok(await _mediator.Send(paymentCommand));
        }
    }
}
