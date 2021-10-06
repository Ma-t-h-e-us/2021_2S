using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.webApi.Domains
{
    public partial class TipoDeUsuario
    {
        public TipoDeUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdTipoDeUsuario { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
