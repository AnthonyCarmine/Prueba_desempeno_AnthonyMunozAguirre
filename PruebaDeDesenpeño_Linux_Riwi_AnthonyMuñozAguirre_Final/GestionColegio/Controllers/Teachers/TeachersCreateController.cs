using GestionColegio.Services;
using Microsoft.AspNetCore.Mvc;
using GestionColegio.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TeachersCreateController : ControllerBase
    {
        public readonly ITeachersRepository _teachersRepository;

        public TeachersCreateController(ITeachersRepository teachersRepository)
        {
            _teachersRepository = teachersRepository;
        }
        [HttpPost]
        public IActionResult Create([FromBody] Teacher teacher)
        {
            try
            {
                _teachersRepository.add(teacher);
                return Ok(teacher);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al crear el profesor");
            }
        }
    }
}