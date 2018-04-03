using Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Dominio;

namespace DadoMemoria
{
    public class FabricanteMemoria : IFabricanteRepositorio
    {
        public Fabricante criar(string nome)
        {
            throw new NotImplementedException();
        }

        public List<Fabricante> todosFabricantes()
        {
            throw new NotImplementedException();
        }

        IQueryable<Fabricante> IFabricanteRepositorio.todosFabricantes()
        {
            throw new NotImplementedException();
        }
    }
}
