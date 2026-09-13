using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ISender _mediator;

        public BaseController(ISender mediator)
        {
            this._mediator = mediator;
        }
    }
}
