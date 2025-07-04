using System.ComponentModel.DataAnnotations;

namespace ProyectoProgramWebTecnoReparo.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud del campo {0} debe ser entre 3 y 50")]
        public string Name { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo debe ser un correo electronico valido")]
        public string Email { get; set; }



        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Phone(ErrorMessage = "El campo debe ser un numero de telefono valido")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Message { get; set; }
    }
}
