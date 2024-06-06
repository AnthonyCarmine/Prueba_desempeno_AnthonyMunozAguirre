using System.ComponentModel.DataAnnotations;

namespace GestionColegio.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombres es obligatorio.")]
        public string Names { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio.")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "El campo Direccion es obligatorio.")]
        public string Address { get; set; }
       
        [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        public string Email { get; set; }
    }
}