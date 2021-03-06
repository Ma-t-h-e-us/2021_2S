using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Rental_WebApi.Domains;
using Senai_Rental_WebApi.Interfaces;
using Senai_Rental_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _ClienteRepository { get; set; }

        public ClientesController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> ListaCliente = _ClienteRepository.ListarTodos();

            return Ok(ListaCliente);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            ClienteDomain ClienteBuscado = _ClienteRepository.BuscarPorId(id);

            if (ClienteBuscado == null)
            {
                return NotFound("Nehum cliente encontrado");
            }
            return Ok(ClienteBuscado);
        }

        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id, ClienteDomain NovoCliente)
        {
            ClienteDomain ClienteBuscado = _ClienteRepository.BuscarPorId(id);

            if (ClienteBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Cliente Não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _ClienteRepository.AtualizarIdUrl(id, NovoCliente);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(ClienteDomain NovoCliente)
        {
            _ClienteRepository.Cadastrar(NovoCliente);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ClienteRepository.Deletar(id);

            return StatusCode(201);
        }
    }
}
