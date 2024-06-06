using GestionColegio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionColegio.Services;

namespace GestionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersUpdateController : ControllerBase
    {
        private readonly ITeachersRepository _teachersRepository;

        public  TeachersUpdateController(ITeachersRepository teachersRepository)
        {
            _teachersRepository = teachersRepository;
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Teacher teacher)
        {
            try
            {
                var existingTeacher = _teachersRepository.GetById(id);
                if (existingTeacher == null)
                {
                    return NotFound($"No se encontro el profesor con el id {id}");
                }
                _teachersRepository.update(teacher);
                return Ok(teacher);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al actualizar el profesor");
            }
        }
    }
}