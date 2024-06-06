using GestionColegio.Data;
using GestionColegio.Models;
using Microsoft.EntityFrameworkCore;
using GestionColegio.Controllers;

namespace GestionColegio.Services
{
    public class EnrollmentsRepository : IEnrollmentsRepository
    {
        private readonly ColegioContext _context;

        public EnrollmentsRepository(ColegioContext context)
        {
            _context = context;
        }
        public IEnumerable<Enrollment> GetAll()
        {
            try
            {
                var enrollments=_context.Enrollments.Include(m=>m.Course).Include(m=>m.Student).ToList();
                return enrollments;
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener los datos de las incripciones");
            }
        }

        public Enrollment GetById(int id)
        {
            try
            {
                var enrollment = _context.Enrollments.Include(m=>m.Course).Include(m=>m.Student).FirstOrDefault(m=>m.Id==id);
                if (enrollment == null)
                {
                    throw new KeyNotFoundException($"No se encontro la inscripcion con el id {id}");
                }
                return enrollment;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch(Exception)
            {
                throw new Exception("Error al obtener los datos de inscripcion");
            }
        }

        public void add(Enrollment enrollment)
        {
            try
            {
                _context.Enrollments.Add(enrollment);
                _context.SaveChanges();
                var student = _context.Students.Find(enrollment.StudentId);
                var course = _context.Courses.Find(enrollment.CourseId);
                 MailController Email = new MailController();
            Email.EnviarCorreo(student.Email, student.Names, course.Name, course.Description, enrollment.Date);
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar la inscripcion");
            }
        }
        
        public void update(Enrollment enrollment)
        {
            try
            {
                _context.Enrollments.Update(enrollment);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error al actualizarla inscripción");
            }
        }
    }
}