using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAsistencia.Models
{
    public class Programa
    {
        public int ProgramaId { get; set; } 
        [Required]
        [MaxLength(512)]
        public string Nombre { get; set; } 
        [Required]
        [MaxLength(5, ErrorMessage = "{0} Maximo de {1} caracteres.")]
        public string Version { get; set; } 
        [Required]
        [MaxLength(9)]
        public string Codigo { get; set; } 

        public bool Estado { get; set; } = true;

        //Propiedad de Navegacion.

        public ICollection<Competencia> ProgramaCompetencia { get; set; }



    }
}