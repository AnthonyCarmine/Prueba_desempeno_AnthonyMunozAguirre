using GestionColegio.Services;
using Microsoft.AspNetCore.Mvc;
using GestionColegio.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersReadController : ControllerBase
    {
        public readonly ITeachersRepository _teachersRepository;

        public TeachersReadController(ITeachersRepository teachersRepository)
        {
            _teachersRepository = teachersRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetTeachers()
        {
            try
            {
                var teachers=_teachersRepository.GetAll();
                return Ok(teachers);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al obtener los profesores");
            }
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Teacher>> GetDoctor(int id)
        {
            try
            {
                var teacher=_teachersRepository.GetById(id);
                return Ok(teacher);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Profesor no encontrado");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al obtener el profesor");
            }
        }
    }
}