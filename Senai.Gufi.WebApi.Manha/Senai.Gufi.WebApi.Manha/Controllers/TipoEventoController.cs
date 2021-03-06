﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using Senai.Gufi.WebApi.Manha.Repositories;

namespace Senai.Gufi.WebApi.Manha.Controllers
{
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository { get; set; }

        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoEventoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoEvento eventoBuscado = _tipoEventoRepository.BuscarPorId(id);

            if (eventoBuscado == null)
            {
                return NotFound("Usuário não Encontrado!");
            }
            return Ok(_tipoEventoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(TipoEvento novoTipoEvento)
        {
            _tipoEventoRepository.Cadastrar(novoTipoEvento);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoEvento tipoEventoAtualizado)
        {

            try
            {
                _tipoEventoRepository.Atualizar(id, tipoEventoAtualizado);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipoEventoRepository.Deletar(id);
            return StatusCode(200);

        }

    }
}