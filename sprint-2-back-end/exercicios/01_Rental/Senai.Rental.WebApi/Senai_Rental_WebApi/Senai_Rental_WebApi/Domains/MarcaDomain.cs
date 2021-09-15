using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebApi.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) Marca
    /// </summary>
    public class MarcaDomain
    {
        public int idMarca { get; set; }
        public string nomeMarca { get; set; }
    }
}
