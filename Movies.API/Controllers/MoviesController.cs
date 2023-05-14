using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Dto;
using Movies.Application.Queries;

namespace Movies.API.Controllers
{
    [Route("api/movies")]
    public class MoviesController : Controller
    {
        private readonly IMediator _mediator;
        public MoviesController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// Gets list of movies by specific filters.
        /// </summary>

        [ProducesResponseType(typeof(IEnumerable<MovieDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetMovies([FromQuery] GetMoviesQuery query)
        {
            var products = await _mediator.Send(query);
            return Ok(products);
        }
    }
}
