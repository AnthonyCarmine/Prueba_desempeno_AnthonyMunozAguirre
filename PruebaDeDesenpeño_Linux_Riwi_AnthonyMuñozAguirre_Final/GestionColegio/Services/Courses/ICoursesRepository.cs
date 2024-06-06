using GestionColegio.Models;


namespace GestionColegio.Services
{
    public interface ICoursesRepository
    {
        IEnumerable<Course> GetAll();

        Course GetById(int id);

        void add(Course course);

        void update(Course course);
    }
}