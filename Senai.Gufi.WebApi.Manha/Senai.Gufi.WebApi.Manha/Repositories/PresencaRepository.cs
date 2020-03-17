using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Presenca PresencaAtualizada)
        {
            Presenca presencaBuscada = ctx.Presenca.FirstOrDefault(p => p.IdPresenca == id);

            Evento presencaEvento = ctx.Evento.FirstOrDefault(e => e.IdEvento == PresencaAtualizada.FkEvento);

            if (presencaEvento.DataEvento > DateTime.Now)
            {
                presencaBuscada.Situacao = PresencaAtualizada.Situacao;
                presencaBuscada.FkUsuario = PresencaAtualizada.FkUsuario;
                presencaBuscada.FkEvento = PresencaAtualizada.FkEvento;

                ctx.Presenca.Update(presencaBuscada);
                ctx.SaveChanges();
            }
                        
        }

        public Presenca BuscarPorId(int id)
        {
            Presenca presencaBuscada = ctx.Presenca.FirstOrDefault(p => p.IdPresenca == id);

            return presencaBuscada;
        }

        public void Cadastrar(Presenca novaPresenca)
        {
            ctx.Presenca.Add(novaPresenca);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Presenca.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Presenca> Listar()
        {
            return ctx.Presenca.ToList();
        }
    }
}
