using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Instituicao InstituicaoAtualizada)
        {
            Instituicao instituicaoBuscada = ctx.Instituicao.FirstOrDefault(i => i.IdInstituicao == id);

            instituicaoBuscada.NomeFantasia = InstituicaoAtualizada.NomeFantasia;
            instituicaoBuscada.Cnpj = InstituicaoAtualizada.Cnpj;
            instituicaoBuscada.Endereco = InstituicaoAtualizada.Endereco;

            ctx.Instituicao.Update(instituicaoBuscada);

            ctx.SaveChanges();
        }

        public Instituicao BuscarPorId(int id)
        {
            Instituicao instituicaoBuscada = ctx.Instituicao.FirstOrDefault(i => i.IdInstituicao == id);

            if (instituicaoBuscada == null)
            {
                return null;
            }
            return instituicaoBuscada;
        }

        public void Cadastrar(Instituicao novaInstituicao)
        {
            ctx.Instituicao.Add(novaInstituicao);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Instituicao.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
            return ctx.Instituicao.ToList();
        }
    }
}
