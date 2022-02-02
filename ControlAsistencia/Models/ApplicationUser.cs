using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAsistencia.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required (ErrorMessage = "El {0} Es Obligatorio.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El {0} Es Obligatorio.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "La {0} Es Obligatorio.")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El {0} Es Obligatorio.")]
        public string Pais { get; set; }
    }
}
