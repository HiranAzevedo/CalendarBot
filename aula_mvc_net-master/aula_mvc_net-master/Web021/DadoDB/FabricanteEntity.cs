using Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Dominio;

namespace DadoDB
{
    public class FabricanteEntity : IFabricanteRepositorio
    {
        public Fabricante criar(string nome)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Fabricante> todosFabricantes()
        {
            return new Context().Fabricantes;
        }
    }
}
