using GestionColegio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionColegio.Services;

namespace GestionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsUpdateController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;

        public  StudentsUpdateController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Student Student)
        {
            try
            {
                var existingStudent = _studentsRepository.GetById(id);
                if (existingStudent == null)
                {
                    return NotFound($"No se encontro el estudiante con el id {id}");
                }
                _studentsRepository.update(Student);
                return Ok(Student);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al actualizar el profesor");
            }
        }
    }
}