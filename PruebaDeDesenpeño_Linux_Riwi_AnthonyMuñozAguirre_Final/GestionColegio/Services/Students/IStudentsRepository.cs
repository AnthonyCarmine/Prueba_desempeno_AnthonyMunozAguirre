using GestionColegio.Models;

namespace GestionColegio.Services
{
    public interface IStudentsRepository
    {
        IEnumerable<Student> GetAll();

        Student GetById(int id);

        void add(Student student);
        
        void update(Student student);
    }
}