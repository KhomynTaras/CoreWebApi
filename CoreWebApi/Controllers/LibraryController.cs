using BL.Services.LibraryService;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLibraries(float latitude, float longtitude)
        {
            return Ok(await _libraryService.GetNearestLibraries(
                new Point
                {
                    Latitude = latitude,
                    Longitude = longtitude
                }));

        }
    }
}
