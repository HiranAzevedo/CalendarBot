using Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorio
{
    public interface IFabricanteRepositorio
    {
        Fabricante criar(string nome);
        IQueryable<Fabricante> todosFabricantes();

    }
}
