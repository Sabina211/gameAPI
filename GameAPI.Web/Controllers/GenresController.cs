using GameAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Web.Controllers
{
    [ApiController]
    [Route("genres")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        /// <summary>
        /// Получение всех жанров игр
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IActionResult GetAll()
        {
            var genres = _genreService.GetAll();
            return Ok(new { genres });
        }
    }
}
