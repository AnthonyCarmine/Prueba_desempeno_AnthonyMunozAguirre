using GestionColegio.Services;
using Microsoft.AspNetCore.Mvc;
using GestionColegio.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
  public class CoursesReadController : ControllerBase
    {
        public readonly ICoursesRepository _coursesRepository;

        public CoursesReadController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            try
            {
                var courses=_coursesRepository.GetAll();
                return Ok(courses);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al obtener los cursos");
            }
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Course>> GetCourse(int id)
        {
            try
            {
                var course=_coursesRepository.GetById(id);
                return Ok(course);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("curso no encontrado");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al obtener el curso");
            }
        }
    }
}