using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stone.AppStore.Application.Interfaces;
using Stone.AppStore.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.AppStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly IAppService _appService;

        public AppController(IAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppModel>>> Get()
        {
            var apps = await _appService.GetApps();
            if (apps == null)
            {
                return NotFound("Apps not found");
            }
            return Ok(apps);
        }

        [HttpGet("{id:guid}", Name = "GetApp")]
        public async Task<ActionResult<AppModel>> Get(Guid id)
        {
            var app = await _appService.GetById(id);
            if (app == null)
            {
                return NotFound("App not found");
            }
            return Ok(app);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AppModel appModel)
        {
            if (appModel == null)
                return BadRequest("Invalid Data");

            await _appService.Add(appModel);

            return Ok(appModel);
        }
    }
}
