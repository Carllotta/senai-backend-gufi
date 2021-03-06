﻿using System;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Presenca = new HashSet<Presenca>();
        }

        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Genero { get; set; }
        public int? FkTipoUsuario { get; set; }

        public TipoUsuario FkTipoUsuarioNavigation { get; set; }
        public ICollection<Presenca> Presenca { get; set; }
    }
}
