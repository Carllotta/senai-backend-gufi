using Senai.Gufi.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Interfaces
{
    interface IPresencaRepository
    {
        List<Presenca> Listar();

        Presenca BuscarPorId(int id);

        void Cadastrar(Presenca novaPresenca);

        void Deletar(int id);

        void Atualizar(int id, Presenca PresencaAtualizada);
    }
}
