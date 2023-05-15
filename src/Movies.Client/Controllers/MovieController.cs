using Microsoft.AspNetCore.Mvc;
using Movies.Client.Services;

namespace Movies.Client.Controllers
{
    public class MovieController : Controller
    {

        private readonly MovieService _service;

        public MovieController(MovieService service)
        {
            _service = service;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetMoviesAsync());
        }

    }
}
