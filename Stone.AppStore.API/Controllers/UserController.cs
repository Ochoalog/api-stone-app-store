using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stone.AppStore.Domain.Entities;
using Stone.AppStore.Domain.Interfaces;
using Stone.AppStore.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stone.AppStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _repository;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _repository.GetByIdAsync(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
