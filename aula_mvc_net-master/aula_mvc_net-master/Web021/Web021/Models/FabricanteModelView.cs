using Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web021.Models
{
    public class FabricanteModelView
    {
        public string nome { get; set; }
        public int id { get; set; }

        public FabricanteModelView fromModel(Fabricante model)
        {
            this.id = model.id;
            this.nome = model.nome;
            return this;
        }
    }
}