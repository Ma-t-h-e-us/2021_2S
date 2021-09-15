using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebApi.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) Empresa
    /// </summary>
    public class EmpresaDomain
    {
        public int idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }
    }
}
