using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityAlpha.Models;

namespace EntityAlpha.Controllers
{
    public class AluguelsController : Controller
    {
        private EntityAlphaContext db = new EntityAlphaContext();

        // GET: Aluguels
        public ActionResult Index()
        {
            var alugueis = db.Alugueis.Include(a => a.carro).Include(a => a.usuario);
            return View(alugueis.ToList());
        }

        // GET: Aluguels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguel aluguel = db.Alugueis.Find(id);
            if (aluguel == null)
            {
                return HttpNotFound();
            }
            return View(aluguel);
        }

        // GET: Aluguels/Create
        public ActionResult Create()
        {
            ViewBag.carroId = new SelectList(db.Carroes, "id", "placa");
            ViewBag.usuarioId = new SelectList(db.Usuarios, "id", "nome");
            return View();
        }

        // POST: Aluguels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,carroId,usuarioId,locacao,prazo,devolucao")] Aluguel aluguel)
        {
            if (ModelState.IsValid)
            {
                db.Alugueis.Add(aluguel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.carroId = new SelectList(db.Carroes, "id", "placa", aluguel.carroId);
            ViewBag.usuarioId = new SelectList(db.Usuarios, "id", "nome", aluguel.usuarioId);
            return View(aluguel);
        }

        // GET: Aluguels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguel aluguel = db.Alugueis.Find(id);
            if (aluguel == null)
            {
                return HttpNotFound();
            }
            ViewBag.carroId = new SelectList(db.Carroes, "id", "placa", aluguel.carroId);
            ViewBag.usuarioId = new SelectList(db.Usuarios, "id", "nome", aluguel.usuarioId);
            return View(aluguel);
        }

        // POST: Aluguels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,carroId,usuarioId,locacao,prazo,devolucao")] Aluguel aluguel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluguel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.carroId = new SelectList(db.Carroes, "id", "placa", aluguel.carroId);
            ViewBag.usuarioId = new SelectList(db.Usuarios, "id", "nome", aluguel.usuarioId);
            return View(aluguel);
        }

        // GET: Aluguels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguel aluguel = db.Alugueis.Find(id);
            if (aluguel == null)
            {
                return HttpNotFound();
            }
            return View(aluguel);
        }

        // POST: Aluguels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluguel aluguel = db.Alugueis.Find(id);
            db.Alugueis.Remove(aluguel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
