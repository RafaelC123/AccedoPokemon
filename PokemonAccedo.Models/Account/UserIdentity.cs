using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAccedo.Models.Account
{
    public class UserIdentity : IdentityUser
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MinLength(3, ErrorMessage = "El campo {0} debe tener minimo 3 caracteres")]
        [MaxLength(12, ErrorMessage = "El campo {0} no puede tener mas de 12 caracteres")]
        public string FirstName { get; set; }

        [MinLength(3, ErrorMessage = "El campo {0} debe tener minimo 3 caracteres")]
        [MaxLength(12, ErrorMessage = "El campo {0} no puede tener mas de 12 caracteres")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MinLength(3, ErrorMessage = "El campo {0} debe tener minimo 3 caracteres")]
        [MaxLength(12, ErrorMessage = "El campo {0} no puede tener mas de 12 caracteres")]
        public string FirstSurName { get; set; }


        [MinLength(3, ErrorMessage = "El campo {0} debe tener minimo 3 caracteres")]
        [MaxLength(12, ErrorMessage = "El campo {0} no puede tener mas de 12 caracteres")]
        public string SecondSurName { get; set; }
    }
}
