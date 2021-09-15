using Senai_Rental_WebApi.Domains;
using Senai_Rental_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string stringConexao = "Data Source=DESKTOP-EJ47PRO\\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";
        
        public void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "Update clientes set nomeCliente = @nomeCliente, sobrenomeCliente = @sobrenomeCliente, cpfCliente = @cpfCliente where idCliente = @idCliente";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", clienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", clienteAtualizado.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@cpfCliente", clienteAtualizado.cpfCliente);
                    cmd.Parameters.AddWithValue("@idCliente", clienteAtualizado.idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "Select * from Clientes where idCliente = @idCliente";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(reader["idCliente"]),
                            nomeCliente = reader["nomeCliente"].ToString(),
                            sobrenomeCliente = reader["sobrenomeCliente"].ToString(),
                            cpfCliente = Convert.ToInt32(reader["cpfCliente"])
                        };
                        return clienteBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "insert into clientes (nomeCliente, sobrenomeCliente, cpfCliente) values (@nomeCliente, @sobrenomeCliente, @cpfCliente)";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@cpfCliente", novoCliente.cpfCliente);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "delete from Clientes where idCliente = @idCliente";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaClientes = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "Select * from Clientes";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(rdr[0]),
                            nomeCliente = rdr[1].ToString(),
                            sobrenomeCliente = rdr[2].ToString(),
                            cpfCliente = Convert.ToInt32(rdr[3])
                        };
                        listaClientes.Add(cliente);
                    }
                }
            }
            return listaClientes;
        }
    }
}
