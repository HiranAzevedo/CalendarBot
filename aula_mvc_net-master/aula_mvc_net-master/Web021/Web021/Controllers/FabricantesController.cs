using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DadoDB;
using Negocio.Dominio;
using Negocio.Repositorio;
using DadoMemoria;
using Servico;
using Web021.Models;

namespace Web021.Controllers
{
    public class FabricantesController : Controller
    {
        private FabricanteServico servico;

        public FabricantesController()
        {
            this.servico = new FabricanteServico(new FabricanteEntity());
        }

        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(this.servico.obterFabricantes().ToList().ConvertAll(
                (model) => new FabricanteModelView
                {
                    id = model.id,
                    nome = model.nome
                }
            ));
        }

        // GET: Fabricantes 2
        public ActionResult Index2()
        {
            return View(this.servico.obterFabricantes().ToList().ConvertAll(
                (model) => new FabricanteModelView
                {
                    id = model.id,
                    nome = model.nome
                }
            ));
        }


    }
}
