using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAccedo.Dtos.Account.Request
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MinLength(3, ErrorMessage = "El campo {0} debe tener minimo 3 caracteres")]
        [MaxLength(12, ErrorMessage = "El campo {0} no puede tener mas de 12 caracteres")]
        public string FirstName { get; set; }

        
        
        public string SecondName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MinLength(3, ErrorMessage = "El campo {0} debe tener minimo 3 caracteres")]
        [MaxLength(12, ErrorMessage = "El campo {0} no puede tener mas de 12 caracteres")]
        public string FirstSurName { get; set; }


        public string SecondSurName { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
