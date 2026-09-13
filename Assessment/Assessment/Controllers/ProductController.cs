using Applications.Handlers.Products.Commands;
using Applications.Handlers.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        public ProductController(ISender mediator) : base(mediator)
        {

        }

        [AllowAnonymous]
        [HttpGet("Health-Checkup")]
        public async Task<IActionResult> GetHealthCheckup()
        {
            var result = await this._mediator.Send(new GetHealthCheckupQuery());
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await this._mediator.Send(new GetProductsQuery());
            return Ok(result);
        }

        [HttpPost("SortCharacter/{text}")]
        public async Task<IActionResult> SortCharacter(string text)
        {
            var result = await this._mediator.Send(new SortCharacterQuery(text));
            return Ok(result);
        }
    }
}
