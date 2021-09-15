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
    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepository _VeiculoRepository { get; set; }

        public VeiculosController()
        {
            _VeiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> ListaVeiculo = _VeiculoRepository.ListarTodos();

            return Ok(ListaVeiculo);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculoDomain VeiculoBuscado = _VeiculoRepository.BuscarPorId(id);

            if (VeiculoBuscado == null)
            {
                return NotFound("Nehum Veiculo encontrado");
            }
            return Ok(VeiculoBuscado);
        }

        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id, VeiculoDomain NovoVeiculo)
        {
            VeiculoDomain VeiculoBuscado = _VeiculoRepository.BuscarPorId(id);

            if (VeiculoBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Veiculo Não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _VeiculoRepository.AtualizarIdUrl(id, NovoVeiculo);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain NovoVeiculo)
        {
            _VeiculoRepository.Cadastrar(NovoVeiculo);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _VeiculoRepository.Deletar(id);

            return StatusCode(201);
        }
    }
}

