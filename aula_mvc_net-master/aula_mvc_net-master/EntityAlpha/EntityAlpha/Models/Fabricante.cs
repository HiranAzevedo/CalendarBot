using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityAlpha.Models
{
    public class Fabricante
    {
        public int id { get; set; }
        public string nome { get; set; }

        public virtual List<Modelo> modelos { get; set; }
    }
}