using GestionColegio.Services;
using Microsoft.AspNetCore.Mvc;
using GestionColegio.Models;
using Microsoft.EntityFrameworkCore;
using GestionColegio.Controllers;

namespace GestionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EnrollmentsCreateController : ControllerBase
    {
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public  EnrollmentsCreateController(IEnrollmentsRepository enrollmentsRepository)
        {
            _enrollmentsRepository = enrollmentsRepository;
        }
        [HttpPost]
        public IActionResult Create([FromBody] Enrollment enrollment)
        {
            try
            {
                _enrollmentsRepository.add(enrollment);
                return Ok(enrollment);
    
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al crear el profesor");
            }
        }
    }
}