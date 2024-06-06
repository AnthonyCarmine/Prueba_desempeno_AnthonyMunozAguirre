using GestionColegio.Data;
using GestionColegio.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionColegio.Services
{
    public class TeachersRepository : ITeachersRepository
    {
        private readonly ColegioContext _context;

        public TeachersRepository(ColegioContext context)
        {
            _context = context;
        }
        public IEnumerable<Teacher> GetAll()
        {
            try
            {
                return _context.Teachers.ToList();
            }
            catch(Exception)
            {
                throw new Exception("Error al obtener los datos de los profesores");
            }
        }
        public Teacher GetById(int id)
        {
            try
            {
                var teacher = _context.Teachers.Find(id);
                if (teacher == null)
                {
                    throw new KeyNotFoundException($"No se encontro el profesor con el id {id}");
                }
                return teacher;
            }
            catch(KeyNotFoundException)
            {
                throw;
            }
            catch(Exception)
            {
                throw new Exception("Error al obtener los datos del profesor");
            }
        }
        public void add(Teacher teacher)
        {
            try
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                throw new Exception("Error al agregar el profesor");
            }
        }
        public void update (Teacher teacher)
        {
            try
            {
                _context.Teachers.Update(teacher);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                throw new Exception("Error al actualizar el profesor");
            }
        }
    }
}