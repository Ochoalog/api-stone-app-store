using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]
    public class AppController : ControllerBase
    {
        private readonly IAppService _appService;

        public AppController(IAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        /// <summary>
        ///     Action to list all Apps
        /// </summary>
        /// <returns>Returns a list of apps</returns>
        /// <response code="200">Returned if the list of apps</response>
        /// <response code="404">Returned if the order could not be found with the provided id</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AppModel>>> Get()
        {
            var apps = await _appService.GetApps();
            if (apps == null)
            {
                return NotFound("Nothing app found");
            }
            return Ok(apps);
        }

        /// <summary>
        ///    Action to return one app by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Returned if the app returned with success</response>
        /// <response code="400">Returned if the app could not be found with the provided id</response>
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

        /// <summary>
        ///     Action to create one App
        /// </summary>
        /// <param name="appModel"></param>
        /// <returns></returns>
        /// <response code="200">Returned if the app was created with success</response>
        /// <response code="400">Returned if the app could not be found with the provided id</response>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AppModel appModel)
        {
            try
            {
                if (appModel == null)
                    return BadRequest("Invalid Data");

                await _appService.Add(appModel);

                return Ok(appModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}
