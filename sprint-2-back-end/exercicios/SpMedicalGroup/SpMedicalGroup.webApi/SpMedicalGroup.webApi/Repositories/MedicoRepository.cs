using SpMedicalGroup.webApi.Domains;
using SpMedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        public void Atualizar(int IdMedico, Medico PacienteAtualizado)
        {
            throw new NotImplementedException();
        }

        public Medico BuscarPorId(int IdMedico)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Medico NovoMedico)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int IdMedico)
        {
            throw new NotImplementedException();
        }

        public List<Medico> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
