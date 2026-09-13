using Applications.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(ISender mediator) : base(mediator)
        {

        }

        [HttpGet("Health-Checkup")]
        public async Task<IActionResult> GetHealthCheckup()
        {
            var result = await this._mediator.Send(new GetHealthCheckupQuery());
            return Ok(result);
        }
    }
}
