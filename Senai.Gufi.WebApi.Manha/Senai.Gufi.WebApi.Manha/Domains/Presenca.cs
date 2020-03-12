using System;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    public partial class Presenca
    {
        public int IdPresenca { get; set; }
        public string Situacao { get; set; }
        public int? FkUsuario { get; set; }
        public int? FkEvento { get; set; }

        public Evento FkEventoNavigation { get; set; }
        public Usuario FkUsuarioNavigation { get; set; }
    }
}
