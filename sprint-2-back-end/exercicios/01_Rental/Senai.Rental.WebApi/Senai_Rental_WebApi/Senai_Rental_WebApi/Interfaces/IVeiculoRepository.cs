using Senai_Rental_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebApi.Interfaces
{
    /// <summary>
    /// interface responsavel pelo VeiculoRepository
    /// </summary>
    interface IVeiculoRepository
    {
        /// <summary>
        /// Lista todos os veiculos
        /// </summary>
        /// <returns>Uma lista de veiculos</returns>
        List<VeiculoDomain> ListarTodos();

        /// <summary>
        /// Busca um veiculo através do seu id
        /// </summary>
        /// <param name="idVeiculo">id do Veiculo que será buscado</param>
        /// <returns>Um veiculo buscado</returns>
        VeiculoDomain BuscarPorId(int idVeiculo);

        /// <summary>
        /// Cadastra um novo Veiculo
        /// </summary>
        /// <param name="novoVeiculo">Objeto novoVeiculo com os novos dados</param>
        void Cadastrar(VeiculoDomain novoVeiculo);

        /// <summary>
        /// Atualiza um Veiculo existente
        /// </summary>
        /// <param name="idVeiculo">id do Veiculo que será atualizado</param>
        /// <param name="veiculoAtualizado">Objeto veiculoAtualizado com os novos dados atualizados</param>
        void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado);

        /// <summary>
        /// Deleta um Veiculo existente
        /// </summary>
        /// <param name="idVeiculo">id do Veiculo que será deletado</param>
        void Deletar(int idVeiculo);

    }
}
