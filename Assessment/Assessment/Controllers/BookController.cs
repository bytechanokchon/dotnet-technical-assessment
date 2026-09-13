using Applications.Handlers.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    [Authorize]
    public class BookController : BaseController
    {
        public BookController(ISender mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetBookDetail()
        {
            var result = await this._mediator.Send(new GetBookDetailQuery());
            return Ok(result);
        }
    }
}
