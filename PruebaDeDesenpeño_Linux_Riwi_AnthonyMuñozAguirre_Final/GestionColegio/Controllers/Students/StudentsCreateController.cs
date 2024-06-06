using GestionColegio.Services;
using Microsoft.AspNetCore.Mvc;
using GestionColegio.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionColegio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsCreateController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;

        public  StudentsCreateController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }
        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            try
            {
                _studentsRepository.add(student);
                return Ok(student);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor al crear el profesor");
            }
        }
    }
}