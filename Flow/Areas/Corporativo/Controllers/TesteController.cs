using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Flow.Areas.Corporativo.Models;
using Flow.Models;

namespace Flow.Areas.Corporativo.Controllers
{
    public class TesteController : Controller
    {
        private FlowContext db = new FlowContext();

        // GET: Corporativo/Teste
        [Authorize(Roles = "Visualizar")]
        public ActionResult Index()
        {
            return View(db.Testes.ToList());
        }

        // GET: Corporativo/Teste/Details/5
        [Authorize(Roles = "Visualizar")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teste teste = db.Testes.Find(id);
            if (teste == null)
            {
                return HttpNotFound();
            }
            return View(teste);
        }

        // GET: Corporativo/Teste/Create
        [Authorize(Roles = "Criar")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Corporativo/Teste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Criar")]
        public ActionResult Create([Bind(Include = "ID,Descricao,Preco,UltimaCompra,Estoque")] Teste teste)
        {
            if (ModelState.IsValid)
            {
                db.Testes.Add(teste);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teste);
        }

        // GET: Corporativo/Teste/Edit/5
        [Authorize(Roles = "Editar")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teste teste = db.Testes.Find(id);
            if (teste == null)
            {
                return HttpNotFound();
            }
            return View(teste);
        }

        // POST: Corporativo/Teste/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Editar")]
        public ActionResult Edit([Bind(Include = "ID,Descricao,Preco,UltimaCompra,Estoque")] Teste teste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teste).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teste);
        }

        // GET: Corporativo/Teste/Delete/5
        [Authorize(Roles = "Deletar")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teste teste = db.Testes.Find(id);
            if (teste == null)
            {
                return HttpNotFound();
            }
            return View(teste);
        }

        // POST: Corporativo/Teste/Delete/5
        [Authorize(Roles = "Deletar")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teste teste = db.Testes.Find(id);
            db.Testes.Remove(teste);
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
