using GestionColegio.Data;
using GestionColegio.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionColegio.Services
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly ColegioContext _context;

        public StudentsRepository(ColegioContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAll()
        {
            try
            {
                return _context.Students.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener los datos de los estudiantes");
            }
        }
        public Student GetById(int id)
        {
            try
            {
                var student = _context.Students.Find(id);
                if (student == null)
                {
                    throw new KeyNotFoundException($"No se encontro el estudiante con el id {id}");
                }
                return student;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener los datos del estudiante");
            }
        }

        public void add(Student student)
        {
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar el estudiante");
            }
        }
        
        public void update(Student student)
        {
            try
            {
                _context.Students.Update(student);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error al actualizar el estudiante");
            }
        }
    }
}