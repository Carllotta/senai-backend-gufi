using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using Senai.Gufi.WebApi.Manha.Repositories;

namespace Senai.Gufi.WebApi.Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PresencaController : ControllerBase
    {
        private IPresencaRepository _presencaRepository { get; set; }

        public PresencaController()
        {
            _presencaRepository = new PresencaRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_presencaRepository.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Presenca presencaBuscada = _presencaRepository.BuscarPorId(id);

            if (presencaBuscada == null)
            {
                return NotFound("Presença não encontrada!");
            }
            return Ok(presencaBuscada);
        }
        [HttpPost]
        public IActionResult Post(Presenca novaPresenca)
        {
            _presencaRepository.Cadastrar(novaPresenca);
            return Ok("Usuário Cadastrado!");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Presenca presencaAtualizada)
        {
            Presenca presencaBuscada = _presencaRepository.BuscarPorId(id);

            if (presencaBuscada == null)
            {
                return BadRequest("Presença não encontrada!");
            }

            try
            {
                _presencaRepository.Atualizar(id, presencaAtualizada);
                return Ok("Presença atualizada com sucesso!");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Presenca presencaBuscada = _presencaRepository.BuscarPorId(id);

            if (presencaBuscada == null)
            {
                return BadRequest("Presença não encontrada!");
            }
            _presencaRepository.Deletar(id);
            return Ok("Presença Deletada!");
        }
    }
}