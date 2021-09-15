using Senai_Rental_WebApi.Domains;
using Senai_Rental_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = "Data Source=DESKTOP-EJ47PRO\\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";

        public void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryUpdate = "Update Aluguel Set inicioAluguel = @inicioAluguel, fimAluguel = @fimAluguel, idVeiculo = @idVeiculo, idCliente = @idCliente WHERE idAluguel = @idAluguel";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@DataAluguel", aluguelAtualizado.inicioAluguel);
                    cmd.Parameters.AddWithValue("@DataDevolucao", aluguelAtualizado.fimAluguel);
                    cmd.Parameters.AddWithValue("@IdVeiculo", aluguelAtualizado.idVeiculo);
                    cmd.Parameters.AddWithValue("@IdCliente", aluguelAtualizado.idCliente);
                    cmd.Parameters.AddWithValue("@IdAluguel", idAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryListar = "Select idAluguel, inicioAluguel, fimAluguel, nomeCliente, Placa PlacaCarro From Aluguel Inner Join Veiculo On Aluguel.idVeiculo = Veiculo.idVeiculo Inner Join Cliente On Aluguel.idCliente = Cliente.idCliente WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryListar, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain AluguelBuscado = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),

                            inicioAluguel = Convert.ToDateTime(rdr[1]),

                            fimAluguel = Convert.ToDateTime(rdr[2]),

                            cliente = new ClienteDomain()
                            {
                                nomeCliente = rdr[3].ToString()
                            },

                            veiculo = new VeiculoDomain()
                            {
                                placa = rdr[4].ToString()
                            }

                        };
                        return AluguelBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryInsert = "Insert Into Aluguel (idveiculo, idCliente, inicioAluguel, fimAluguel) Values (@idVeiculo, @idCliente, @inicioAluguel, @fimAluguel)";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@VeiculoId", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@ClienteId", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@DataAluguel", novoAluguel.inicioAluguel);
                    cmd.Parameters.AddWithValue("@DataDevolucao", novoAluguel.fimAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryDelete = "Delete From Aluguel Where idAluguel = @idAluguel";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> ListarAluguel = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryListar = "Select idAluguel, inicioAluguel, fimAluguel, nomeCliente, Placa PlacaCarro From Aluguel Inner Join Veiculo On Aluguel.idVeiculo = Veiculo.idVeiculo Inner Join Cliente On Aluguel.idCliente = Cliente.idCliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryListar, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        AluguelDomain Aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),

                            inicioAluguel = Convert.ToDateTime(rdr[1]),

                            fimAluguel = Convert.ToDateTime(rdr[2]),

                            cliente = new ClienteDomain()

                            {
                                nomeCliente = rdr[3].ToString()
                            },

                            veiculo = new VeiculoDomain()
                            {
                                placa = rdr[4].ToString()
                            }

                        };
                        ListarAluguel.Add(Aluguel);
                    }
                }
            }
            return ListarAluguel;
        }
    }
}
