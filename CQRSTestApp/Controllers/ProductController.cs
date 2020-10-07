using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSTestApp.Features.ProductFeatures.Commands;
using CQRSTestApp.Features.ProductFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Crete(CreateProductCommand command) => 
            Ok(await Mediator.Send(command));

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await Mediator.Send(new GetAllProductsQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));

    }
}
