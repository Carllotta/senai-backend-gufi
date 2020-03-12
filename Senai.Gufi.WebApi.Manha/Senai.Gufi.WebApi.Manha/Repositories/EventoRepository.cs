using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Evento eventoAtualizado)
        {
            Evento eventoBuscado = ctx.Evento.Find(id);

            eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento;
            eventoBuscado.DataEvento = eventoAtualizado.DataEvento;
            eventoBuscado.Descricao = eventoAtualizado.Descricao;
            eventoBuscado.AcessoLivre = eventoAtualizado.AcessoLivre;
            eventoBuscado.FkInstituicao = eventoAtualizado.FkInstituicao;
            eventoBuscado.FkTipoEvento = eventoAtualizado.FkTipoEvento;

            ctx.Evento.Update(eventoAtualizado);
            ctx.SaveChanges();

        }

        public Evento BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Evento novoEvento)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Evento> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
