using GestionColegio.Services;
using Microsoft.AspNetCore.Mvc;
using GestionColegio.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsReadController : ControllerBase
    {
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public  EnrollmentsReadController(IEnrollmentsRepository enrollmentsRepository)
        {
            _enrollmentsRepository = enrollmentsRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Enrollment>> GetEnrollments()
        {
            try
            {
                var enrollments=_enrollmentsRepository.GetAll();
                return Ok(enrollments);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al obtener las inscripcion");
            }
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Enrollment>> GetEnrollment(int id)
        {
            try
            {
                var enrollment=_enrollmentsRepository.GetById(id);
                return Ok(enrollment);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("inscripcion no encontrado");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al obtener la inscripcion");
            }
        }
    }
}