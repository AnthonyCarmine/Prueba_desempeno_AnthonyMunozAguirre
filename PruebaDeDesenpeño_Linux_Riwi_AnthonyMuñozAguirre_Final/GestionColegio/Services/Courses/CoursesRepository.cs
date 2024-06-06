using GestionColegio.Data;
using GestionColegio.Models;
using Microsoft.EntityFrameworkCore;
using GestionColegio.Services;
using GestionColegio.Controllers;

namespace GestionColegio.Services
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly ColegioContext _context;
        
        public CoursesRepository(ColegioContext context)
        {
            _context = context;
        }
        public IEnumerable<Course> GetAll()
        {
            try
            {
               var courses =_context.Courses.Include(m=>m.Teacher).ToList();
               return courses;
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener los datos de los cursos");
            }
        }
        
        public Course GetById(int id)
        {
            try
            {
                 var course =_context.Courses.Include(m=>m.Teacher).FirstOrDefault(m=>m.Id==id);
                if (course == null)
                {
                    throw new KeyNotFoundException($"No se encontro el curso con el id {id}");
                }
                return course;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener el curso");
            }
        }

        public void add(Course course)
        {
            try
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                var teacher = _context.Teachers.Find(course.TeacherId);
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar el curso");
            }
        }

        public void update(Course course)
        {
            try
            {
                _context.Courses.Update(course);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error al actualizar el curso");
            }
        }

    }
}