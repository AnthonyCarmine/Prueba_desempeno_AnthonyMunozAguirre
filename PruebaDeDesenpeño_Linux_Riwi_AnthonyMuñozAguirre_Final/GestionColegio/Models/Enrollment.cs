using System.ComponentModel.DataAnnotations;

namespace GestionColegio.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Fecha es obligatorio.")]
        public DateOnly Date { get; set; }
        
        [Required(ErrorMessage = "El campo Id Estudiante es obligatorio.")]
        public int StudentId { get; set; }

        public Student? Student { get; set; }

        [Required(ErrorMessage = "El campo Id Curso es obligatorio.")]
        public int CourseId { get; set; }

        public Course? Course { get; set; }


    }
}