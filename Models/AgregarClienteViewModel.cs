using System.ComponentModel.DataAnnotations;

namespace proyecto_prueba_L5.Models
{
    public class AgregarClienteViewModel
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Dni { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
