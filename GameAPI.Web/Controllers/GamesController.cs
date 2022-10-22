using GameAPI.Application.Services;
using GameAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Web.Controllers
{
    [ApiController]
    [Route("games")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(GameModel game)
        {
            var result = await _gameService.Create(game);
            return Ok(new { id = result });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var games = _gameService.GetAll();
            return Ok(new { games });
        }

        /// <summary>
        /// Получить список игр, у которых есть один из заданных жанров
        /// </summary>
        /// <param name="ids">Id жанров</param>
        /// <returns></returns>

        [HttpGet("getByGenres")]
        public IActionResult GetByGenres([FromQuery] List<Guid> ids)
        {
            var games = _gameService.GetByGenres(ids).Result;
            return Ok(new { games });
        }

        [HttpPut]
        public async Task<IActionResult> Update(GameModel game)
        {
            var result = await _gameService.Update(game);
            return Ok(new { result });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _gameService.Delete(id);
            return Ok();
        }
    }
}
