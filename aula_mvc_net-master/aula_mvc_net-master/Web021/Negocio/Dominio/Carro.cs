using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Dominio
{
    public class Carro
    {
        public int id { get; set; }
        public string placa { get; set; }
        public int quilometragem { get; set; }

        public int modeloId { get; set; }
        public virtual Modelo modelo { get; set; }

        public virtual List<Aluguel> alugueis { get; set; }
    }
}

// Enable-Migrations
// Add-Migration
// Update-Database