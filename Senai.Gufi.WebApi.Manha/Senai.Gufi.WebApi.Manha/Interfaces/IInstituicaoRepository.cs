using Senai.Gufi.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Interfaces
{
    interface IInstituicaoRepository
    {
        List<Instituicao> Listar();

        Instituicao BuscarPorId(int id);

        void Cadastrar(Instituicao novaInstituicao);

        void Deletar(int id);

        void Atualizar(int id, Instituicao InstituicaoAtualizada);
    }
}
