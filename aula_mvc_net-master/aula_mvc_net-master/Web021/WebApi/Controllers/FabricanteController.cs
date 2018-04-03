using DadoDB;
using Negocio.Dominio;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class FabricanteController : ApiController
    {
        private FabricanteServico servico;

        public FabricanteController()
        {
            this.servico = new FabricanteServico(new FabricanteEntity());
        }

        // GET: api/Fabricante
        public IEnumerable<FabricanteMV> Get()
        {
            return this.servico.obterFabricantes().ToList().ConvertAll((model) =>
            {
                return new FabricanteMV
                {
                    id = model.id,
                    nome = model.nome
                };
            });
        }

        // GET: api/Fabricante/5
        public Fabricante Get(int id)
        {
            return new Fabricante();
        }

        // POST: api/Fabricante
        public Fabricante Post([FromBody]Fabricante value)
        {
            return new Fabricante();
        }

        // PUT: api/Fabricante/5
        public Fabricante Put(int id, [FromBody]Fabricante value)
        {
            return new Fabricante();
        }

        // DELETE: api/Fabricante/5
        public void Delete(int id)
        {
        }
    }
}
