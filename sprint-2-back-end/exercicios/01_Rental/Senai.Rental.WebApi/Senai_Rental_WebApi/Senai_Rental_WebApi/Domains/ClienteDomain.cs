using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebApi.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) Cliente
    /// </summary>
    public class ClienteDomain
    {
        public int idCliente { get; set; }
        public string nomeCliente { get; set; }
        public string sobrenomeCliente { get; set; }
        public int cpfCliente { get; set; }
    }
}
