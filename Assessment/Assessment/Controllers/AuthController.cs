using Applications.Handlers.Auths.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(ISender mediator) : base(mediator)
        {
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login()
        {
            var result = await this._mediator.Send(new LoginQuery());
            return Ok(result);
        }
    }
}
