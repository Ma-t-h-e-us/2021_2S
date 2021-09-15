using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebApi.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) Aluguel
    /// </summary>
    public class AluguelDomain
    {
        public int idAluguel { get; set; }
        public int idVeiculo { get; set; }
        public int idCliente { get; set; }
        public DateTime inicioAluguel { get; set; }
        public DateTime fimAluguel { get; set; }
        public VeiculoDomain veiculo { get; set; }
        public ClienteDomain cliente { get; set; }
    }
}
