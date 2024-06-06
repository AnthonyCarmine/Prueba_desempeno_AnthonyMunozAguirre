using GestionColegio.Models;

namespace GestionColegio.Services
{
    public interface ITeachersRepository
    {
        IEnumerable<Teacher> GetAll();

        Teacher GetById(int id);

        void add(Teacher student);
        
        void update(Teacher student);
    }
}