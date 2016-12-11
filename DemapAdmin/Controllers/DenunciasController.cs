using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemapAdmin.Models;

namespace DemapAdmin.Controllers
{
    public class DenunciasController : Controller
    {
        private DEMAPSEntities db = new DEMAPSEntities();

        // GET: Denuncias
        public async Task<ActionResult> Index()
        {
            var tbl_denuncias = db.tbl_denuncias.Include(t => t.tbl_estados_denuncias).Include(t => t.tbl_tipos_productos);
            return View(await tbl_denuncias.ToListAsync());
        }

        // GET: Denuncias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_denuncias tbl_denuncias = await db.tbl_denuncias.FindAsync(id);
            if (tbl_denuncias == null)
            {
                return HttpNotFound();
            }
            return View(tbl_denuncias);
        }

        // GET: Denuncias/Create
        public ActionResult Create()
        {
            ViewBag.EstadoDenunciaID = new SelectList(db.tbl_estados_denuncias, "Id", "Estado");
            ViewBag.TipoProductoID = new SelectList(db.tbl_tipos_productos, "Id", "Tipo");
            return View();
        }

        // POST: Denuncias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TipoProductoID,EstadoDenunciaID,CedulaDenunciante,Producto,Establecimiento,FechaCreacion,Activo,RegistroSanitario")] tbl_denuncias tbl_denuncias)
        {
            if (ModelState.IsValid)
            {
                db.tbl_denuncias.Add(tbl_denuncias);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoDenunciaID = new SelectList(db.tbl_estados_denuncias, "Id", "Estado", tbl_denuncias.EstadoDenunciaID);
            ViewBag.TipoProductoID = new SelectList(db.tbl_tipos_productos, "Id", "Tipo", tbl_denuncias.TipoProductoID);
            return View(tbl_denuncias);
        }

        // GET: Denuncias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_denuncias tbl_denuncias = await db.tbl_denuncias.FindAsync(id);
            if (tbl_denuncias == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoDenunciaID = new SelectList(db.tbl_estados_denuncias, "Id", "Estado", tbl_denuncias.EstadoDenunciaID);
            ViewBag.TipoProductoID = new SelectList(db.tbl_tipos_productos, "Id", "Tipo", tbl_denuncias.TipoProductoID);
            return View(tbl_denuncias);
        }

        // POST: Denuncias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TipoProductoID,EstadoDenunciaID,CedulaDenunciante,Producto,Establecimiento,FechaCreacion,Activo,RegistroSanitario")] tbl_denuncias tbl_denuncias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_denuncias).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoDenunciaID = new SelectList(db.tbl_estados_denuncias, "Id", "Estado", tbl_denuncias.EstadoDenunciaID);
            ViewBag.TipoProductoID = new SelectList(db.tbl_tipos_productos, "Id", "Tipo", tbl_denuncias.TipoProductoID);
            return View(tbl_denuncias);
        }

        // GET: Denuncias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_denuncias tbl_denuncias = await db.tbl_denuncias.FindAsync(id);
            if (tbl_denuncias == null)
            {
                return HttpNotFound();
            }
            return View(tbl_denuncias);
        }

        // POST: Denuncias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_denuncias tbl_denuncias = await db.tbl_denuncias.FindAsync(id);
            db.tbl_denuncias.Remove(tbl_denuncias);
            await db.SaveChangesAsync();
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
