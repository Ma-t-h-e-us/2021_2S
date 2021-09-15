using Senai_Rental_WebApi.Domains;
using Senai_Rental_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private string stringConexao = "Data Source=DESKTOP-EJ47PRO\\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";
        public void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryUpdate = "Update Veiculo Set Placa = @Placa where IdVeiculo = @idVeiculo";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(QueryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Placa", veiculoAtualizado.placa);
                    cmd.Parameters.AddWithValue("@IdVeiculo", idVeiculo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryBusca = "Select idVeiculo, NomeModelo, NomeMarca, NomeEmpresa, Placa From Veiculo Right Join Modelo On Veiculo.idModelo = Modelo.idModelo Right Join Empresa On Veiculo.idEmpresa = Empresa.idEmpresa Right Join Marca On Modelo.idMarca = Marca.idMarca  Where idVeiculo = @IdVeiculo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryBusca, con))
                {
                    cmd.Parameters.AddWithValue("@IdVeiculo", idVeiculo);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculoDomain VeiculoBuscado = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            modelo = new ModeloDomain()
                            {
                                nomeModelo = rdr[1].ToString(),
                                marca = new MarcaDomain()
                                {
                                    nomeMarca = rdr[2].ToString()
                                }
                            },
                            empresa = new EmpresaDomain()
                            {
                                nomeEmpresa = rdr[3].ToString()
                            },
                            placa = rdr[4].ToString()
                        };

                        return VeiculoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryInsert = "Insert Into Veiculo (idEmpresa, idModelo, Placa) Values (@idEmpresa, @idModelo, @Placa)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idEmpresa", novoVeiculo.idEmpresa);
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@Placa", novoVeiculo.placa);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryInsert = "Delete From Veiculo Where idVeiculo = @IdVeiculo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdVeiculo", idVeiculo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> ListarVeiculo = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryListar = "Select idVeiculo, NomeModelo, NomeMarca, NomeEmpresa, Placa From Veiculo Right Join Modelo On Veiculo.idModelo = Modelo.idModelo Right Join Empresa On Veiculo.idEmpresa = Empresa.idEmpresa Right Join Marca On Modelo.idMarca = Marca.idMarca";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryListar, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        VeiculoDomain Veiculo = new VeiculoDomain()
                        {

                            idVeiculo = Convert.ToInt32(rdr[0]),
                            modelo = new ModeloDomain()
                            {
                                nomeModelo = rdr[1].ToString(),
                                marca = new MarcaDomain()
                                {
                                    nomeMarca = rdr[2].ToString(),
                                }
                            },
                            empresa = new EmpresaDomain()
                            {
                                nomeEmpresa = rdr[3].ToString()
                            },
                            placa = rdr[4].ToString()

                        };
                        ListarVeiculo.Add(Veiculo);
                    }
                }
            }
            return ListarVeiculo;
        }
    }
}
