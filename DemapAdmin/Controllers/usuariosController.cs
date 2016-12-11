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
    public class usuariosController : Controller
    {
        private DEMAPSEntities db = new DEMAPSEntities();

        // GET: usuarios
        public async Task<ActionResult> Index()
        {
            var tbl_usuarios = db.tbl_usuarios.Include(t => t.tbl_perfiles_usuarios);
            return View(await tbl_usuarios.ToListAsync());
        }

        // GET: usuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuarios tbl_usuarios = await db.tbl_usuarios.FindAsync(id);
            if (tbl_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tbl_usuarios);
        }

        // GET: usuarios/Create
        public ActionResult Create()
        {
            ViewBag.PerfilUsuarioID = new SelectList(db.tbl_perfiles_usuarios, "Id", "Perfil");
            return View();
        }

        // POST: usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PerfilUsuarioID,Nombre,Apellido,Usuario,Contrasena,FechaCreacion,CreadoPor,Activo")] tbl_usuarios tbl_usuarios)
        {
            if (ModelState.IsValid)
            {
                db.tbl_usuarios.Add(tbl_usuarios);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PerfilUsuarioID = new SelectList(db.tbl_perfiles_usuarios, "Id", "Perfil", tbl_usuarios.PerfilUsuarioID);
            return View(tbl_usuarios);
        }

        // GET: usuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuarios tbl_usuarios = await db.tbl_usuarios.FindAsync(id);
            if (tbl_usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerfilUsuarioID = new SelectList(db.tbl_perfiles_usuarios, "Id", "Perfil", tbl_usuarios.PerfilUsuarioID);
            return View(tbl_usuarios);
        }

        // POST: usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PerfilUsuarioID,Nombre,Apellido,Usuario,Contrasena,FechaCreacion,CreadoPor,Activo")] tbl_usuarios tbl_usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_usuarios).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PerfilUsuarioID = new SelectList(db.tbl_perfiles_usuarios, "Id", "Perfil", tbl_usuarios.PerfilUsuarioID);
            return View(tbl_usuarios);
        }

        // GET: usuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuarios tbl_usuarios = await db.tbl_usuarios.FindAsync(id);
            if (tbl_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tbl_usuarios);
        }

        // POST: usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_usuarios tbl_usuarios = await db.tbl_usuarios.FindAsync(id);
            db.tbl_usuarios.Remove(tbl_usuarios);
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
