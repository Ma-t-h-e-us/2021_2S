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
    public class AlugueisController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }

        public AlugueisController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> ListaVeiculo = _AluguelRepository.ListarTodos();

            return Ok(ListaVeiculo);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AluguelDomain AluguelBuscado = _AluguelRepository.BuscarPorId(id);

            if (AluguelBuscado == null)
            {
                return NotFound("Nehum Veiculo encontrado");
            }
            return Ok(AluguelBuscado);
        }

        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id, AluguelDomain NovoAluguel)
        {
            AluguelDomain AluguelBuscado = _AluguelRepository.BuscarPorId(id);

            if (AluguelBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Aluguel Não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _AluguelRepository.AtualizarIdUrl(id, NovoAluguel);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain NovoAluguel)
        {
            _AluguelRepository.Cadastrar(NovoAluguel);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _AluguelRepository.Deletar(id);

            return StatusCode(201);
        }
    }
}
