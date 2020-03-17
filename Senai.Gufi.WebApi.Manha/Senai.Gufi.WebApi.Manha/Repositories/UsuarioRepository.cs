using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Usuario UsuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id);

            usuarioBuscado.NomeUsuario = UsuarioAtualizado.NomeUsuario;
            usuarioBuscado.Email = UsuarioAtualizado.Email;
            usuarioBuscado.Senha = UsuarioAtualizado.Senha;
            usuarioBuscado.Genero = UsuarioAtualizado.Genero;
            usuarioBuscado.DataCadastro = usuarioBuscado.DataCadastro;
            usuarioBuscado.Genero = UsuarioAtualizado.Genero;
            usuarioBuscado.FkTipoUsuario = UsuarioAtualizado.FkTipoUsuario;

            ctx.Usuario.Update(usuarioBuscado);

            ctx.SaveChanges();
            
        }

        public Usuario BuscarPorId(int id)
        {
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id);

            if (usuarioBuscado == null)
            {
                return null; 
            }
            return ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            novoUsuario.DataCadastro = DateTime.Now;

            ctx.Usuario.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuario.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }

        public void Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
