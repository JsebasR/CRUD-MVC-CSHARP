using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAsistencia.Models
{
    public class Competencia
    {
        public int CompetenciaId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(512)]
        public string Denominacion { get; set; }
        

        public bool Estado { get; set; } = true;

        //

        public ICollection<Programa> ProgramaCompetencia { get; set; }
    }
}
