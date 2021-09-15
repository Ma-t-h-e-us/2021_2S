using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebApi.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) Veiculo
    /// </summary>
    public class VeiculoDomain
    {
        public int idVeiculo { get; set; }
        public int idEmpresa { get; set; }
        public int idModelo { get; set; }
        public string placa { get; set; }
        public EmpresaDomain empresa { get; set; }
        public ModeloDomain modelo { get; set; }
    }
}
