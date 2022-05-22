using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stone.AppStore.Application.Commands.PaymentCommands;
using Stone.AppStore.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Stone.AppStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        ///     Action to create a new payment in the database.
        /// </summary>
        /// <param name="paymentCommand"></param>
        /// <response code="200">Returned if the payment was created</response>
        /// <response code="400">Returned if the model couldn't be parsed or saved</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Payment>> Post([FromBody] PaymentCommand paymentCommand)
        {
            try
            {
                return Ok(await _mediator.Send(paymentCommand));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
