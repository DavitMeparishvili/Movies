using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Commands;
using Movies.Application.Dto;
using Movies.Application.Queries;

namespace Movies.API.Controllers
{
    [Route("api/watch-lists")]
    public class WatchListsController : Controller
    {
        private readonly IMediator _mediator;
        public WatchListsController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// This endpoint adds WatchList entity to database for specific user
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="movieId">IMBD movie unique identifier.</param>
        /// <returns>Created.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddWatchListCommand([FromBody] AddWatchListCommand request)
        {
            await _mediator.Send(request);
            return StatusCode(201);
        }

        /// <summary>
        /// Gets list of watch list items for the specific user, if it exists.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="watched">Status of watch list item in db will be updated by this value</param>
        /// <returns>List of watchlt for specific user, including movie details, if it exists.</returns>
        [ProducesResponseType(typeof(IEnumerable<WatchListDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetWatchListByUserId([FromQuery] GetWatchListQuery request)
        {
            return Ok(await _mediator.Send(request));
        }


        /// <summary>
        /// Updates watch list watched state for specific user, if it exists.
        /// </summary>
        /// <param name="watchListId">The wathlist identifier.</param>
        /// <param name="WatchedState">Watched status of the watchlist item</param>
        /// <returns>No content.</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch]
        public async Task<IActionResult> ChangeWatchedState([FromBody] ChangeWatchedStateCommand request)
        {
            await _mediator.Send(request);
            return StatusCode(204);
        }
    }
}
