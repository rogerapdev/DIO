using MediatR;
using Mercadinho.API.Application.Categoria.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mercadinho.API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class CategoriaController: Controller
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken)
        {
            var categorias = await _mediator.Send(new GetAllCategoriesQuery(), cancellationToken).ConfigureAwait(false);
            return categorias.Any() ? Ok(categorias) : NoContent();
        }
    }
}
