using System.ComponentModel.DataAnnotations;

namespace GestionColegio.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombres es obligatorio.")]
        public string Names { get; set; }

        [Required(ErrorMessage = "El campo Especialidad es obligatorio.")]
        public string Speciality { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Años de Experiencia es obligatorio.")]
        public int YearsExperience { get; set; }
    }
}