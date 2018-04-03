using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityAlpha.Models
{
    public class Modelo
    {
        public int id { get; set; }
        public string nome { get; set; }

        public int fabricanteId { get; set; }
        public virtual Fabricante fabricante { get; set; }

        public virtual List<Carro> carros { get; set; }

    }
}