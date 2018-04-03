using Negocio.Dominio;
using Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    public class FabricanteServico
    {
        private IFabricanteRepositorio repositorio { get; set; }

        public FabricanteServico(IFabricanteRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public IQueryable<Fabricante> obterFabricantes()
        {
            return this.repositorio.todosFabricantes();
        }

    }
}
