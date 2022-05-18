using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Stone.AppStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppStoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppStoreController(IMediator mediator)
        {
            _mediator = mediator;
        }


    }
}
