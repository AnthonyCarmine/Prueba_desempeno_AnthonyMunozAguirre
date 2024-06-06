using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestionColegio.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombres es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El campo Id del profesor es obligatorio.")]
        public int TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        [Required(ErrorMessage = "El campo Cronograma es obligatorio")]
        public string Schedule { get; set; }

        [Required(ErrorMessage = "El campo duration es obligatorio.")]
        public string Duration { get; set; }

        [Required(ErrorMessage = "El campo Capacidad es obligatorio.")]
        public int Capacity { get; set; }

    }
}