using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAsistencia.Models
{
    public class ProgramaCompetencia
    {
        public int CompetenciaId { get; set; }

        public Competencia Competencia { get; set; }

        public int ProgramaId { get; set; }
        public Programa Programa { get; set; }
    }
}
