using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.webApi.Domains
{
    public partial class AreaMedico
    {
        public AreaMedico()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdAreaMedico { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
