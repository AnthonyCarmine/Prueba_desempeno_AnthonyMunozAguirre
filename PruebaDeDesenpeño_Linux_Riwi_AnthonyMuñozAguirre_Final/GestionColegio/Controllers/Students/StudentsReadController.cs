using GestionColegio.Services;
using Microsoft.AspNetCore.Mvc;
using GestionColegio.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsReadController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;

        public  StudentsReadController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            try
            {
                var students=_studentsRepository.GetAll();
                return Ok(students);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al obtener los profesores");
            }
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Student>> GetStudent(int id)
        {
            try
            {
                var students=_studentsRepository.GetById(id);
                return Ok(students);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("estudiante no encontrado");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al obtener el profesor");
            }
        }
    }
}