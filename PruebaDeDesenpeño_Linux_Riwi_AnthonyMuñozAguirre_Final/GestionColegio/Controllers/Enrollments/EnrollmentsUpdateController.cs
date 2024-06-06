using GestionColegio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionColegio.Services;

namespace GestionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsUpdateController : ControllerBase
    {
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public  EnrollmentsUpdateController(IEnrollmentsRepository enrollmentsRepository)
        {
            _enrollmentsRepository = enrollmentsRepository;
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Enrollment enrollment)
        {
            try
            {
                var existingEnrollment = _enrollmentsRepository.GetById(id);
                if (existingEnrollment == null)
                {
                    return NotFound($"No se encontro la inscripción con el id {id}");
                }
                _enrollmentsRepository.update(enrollment);
                return Ok(enrollment);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al actualizar el profesor");
            }
        }
    }
}