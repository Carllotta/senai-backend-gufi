using Senai.Gufi.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Interfaces
{
    interface IEventoRepository
    {
        List<Evento> Listar();

        void Atualizar(int id, Evento eventoAtualizado);

        void Deletar(int id);

        void Cadastrar(Evento novoEvento);

        Evento BuscarPorId(int id);
             
    }
}
