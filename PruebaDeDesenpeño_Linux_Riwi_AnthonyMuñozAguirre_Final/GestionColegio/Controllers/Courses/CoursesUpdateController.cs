using GestionColegio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionColegio.Services;

namespace GestionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesUpdateController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;

        public  CoursesUpdateController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Course course)
        {
            try
            {
                var existingCourse = _coursesRepository.GetById(id);
                if (existingCourse == null)
                {
                    return NotFound($"No se encontro el curso con el id {id}");
                }
                _coursesRepository.update(course);
                return Ok(course);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al actualizar el profesor");
            }
        }
    }
}