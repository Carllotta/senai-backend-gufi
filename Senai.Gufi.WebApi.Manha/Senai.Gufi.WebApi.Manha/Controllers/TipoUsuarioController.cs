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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_TipoUsuarioRepository.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoUsuario usuarioBuscado = _TipoUsuarioRepository.BuscarPorId(id);

            if(usuarioBuscado == null)
            {
                return NotFound("Usuário não Encontrado");
            }
            return Ok(_TipoUsuarioRepository.BuscarPorId(id));
        }
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            _TipoUsuarioRepository.Cadastrar(novoTipoUsuario);
            return Ok("Usuario Criado");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoUsuario usuarioBuscado = _TipoUsuarioRepository.BuscarPorId(id);

            if(usuarioBuscado == null)
            {
                return StatusCode(404, "Usuário não encontrado");
            }
            _TipoUsuarioRepository.Deletar(id);
            return StatusCode(200);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario usuarioAtualizado)
        {
            try
            {
                TipoUsuario usuarioBuscado = _TipoUsuarioRepository.BuscarPorId(id);
                    if(usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado");
                }
                _TipoUsuarioRepository.Atualizar(id, usuarioAtualizado);
                return StatusCode(200);
            } 
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}