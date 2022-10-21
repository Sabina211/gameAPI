using GameAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Web.Controllers
{
    [ApiController]
    [Route("developers")]
    public class DevelopersController : ControllerBase
    {
        private readonly IDeveloperService _developerService;

        public DevelopersController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var games = _developerService.GetAll();
            return Ok(new { games });
        }
    }
}
