using GestionColegio.Models;

namespace GestionColegio.Services
{
    public interface IEnrollmentsRepository
    {
        IEnumerable<Enrollment> GetAll();

        Enrollment GetById(int id);

        void add(Enrollment enrollment);
        
        void update(Enrollment enrollment);
    }
}