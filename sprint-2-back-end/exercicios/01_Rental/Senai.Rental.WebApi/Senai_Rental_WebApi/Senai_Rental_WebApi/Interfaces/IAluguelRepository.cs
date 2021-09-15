using Senai_Rental_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebApi.Interfaces
{
    /// <summary>
    /// interface responsavel pelo AluguelRepository
    /// </summary>
    interface IAluguelRepository
    {
        /// <summary>
        /// Lista todos os Alugueis
        /// </summary>
        /// <returns>Uma lista de Alugueis</returns>
        List<AluguelDomain> ListarTodos();

        /// <summary>
        /// Busca um Aluguel através do seu id
        /// </summary>
        /// <param name="idAluguel">id do Aluguel que será buscado</param>
        /// <returns>Um Aluguel buscado</returns>
        AluguelDomain BuscarPorId(int idAluguel);

        /// <summary>
        /// Cadastra um novo Aluguel
        /// </summary>
        /// <param name="novoAluguel">Objeto novoAluguel com os novos dados</param>
        void Cadastrar(AluguelDomain novoAluguel);

        /// <summary>
        /// Atualiza um Aluguel existente
        /// </summary>
        /// <param name="idAluguel">id do Aluguel que será atualizado</param>
        /// <param name="aluguelAtualizado">Objeto aluguelAtualizado com os novos dados atualizados</param>
        void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado);

        /// <summary>
        /// Deleta um Aluguel existente
        /// </summary>
        /// <param name="idAluguel">id do Aluguel que será deletado</param>
        void Deletar(int idAluguel);
    }
}
