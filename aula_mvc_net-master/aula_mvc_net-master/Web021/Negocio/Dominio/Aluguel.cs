using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Dominio
{
    public class Aluguel
    {
        public int id { get; set; }

        public int carroId { get; set; }
        public int usuarioId { get; set; }

        public virtual Carro carro { get; set; }
        public virtual Usuario usuario { get; set; }

        public DateTime locacao { get; set; }
        public DateTime prazo { get; set; }
        public DateTime? devolucao { get; set; }

    }
}