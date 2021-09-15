using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebApi.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) Modelo
    /// </summary>
    public class ModeloDomain
    {
        public int idModelo { get; set; }
        public int idMarca { get; set; }
        public string nomeModelo { get; set; }
        public MarcaDomain marca { get; set; }
    }
}
