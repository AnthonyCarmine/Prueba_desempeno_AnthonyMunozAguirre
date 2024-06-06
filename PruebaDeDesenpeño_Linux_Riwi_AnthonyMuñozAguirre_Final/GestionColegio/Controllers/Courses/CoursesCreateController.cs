using GestionColegio.Services;
using Microsoft.AspNetCore.Mvc;
using GestionColegio.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CoursesCreateController : ControllerBase
    {
        public readonly ICoursesRepository _coursesRepository;

        public CoursesCreateController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        [HttpPost]
        public IActionResult Create([FromBody] Course course)
        {
            try
            {
                _coursesRepository.add(course);
                return Ok(course);

            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al crear el curso");
            }
        }
    }
}