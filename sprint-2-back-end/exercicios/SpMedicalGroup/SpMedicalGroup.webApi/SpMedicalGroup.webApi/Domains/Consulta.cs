using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.webApi.Domains
{
    public partial class Consulta
    {
        public long IdConsulta { get; set; }
        public int? IdMedico { get; set; }
        public int? IdPaciente { get; set; }
        public byte? IdSituacao { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
