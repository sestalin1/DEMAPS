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
    public class SeguimientoDenunciasController : Controller
    {
        private DEMAPSEntities db = new DEMAPSEntities();

        // GET: SeguimientoDenuncias
        public async Task<ActionResult> Index()
        {
            return View(await db.View_seguimiento_denuncias.ToListAsync());
        }

        // GET: SeguimientoDenuncias/Details/56
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_seguimiento_denuncias view_seguimiento_denuncias = await db.View_seguimiento_denuncias.FindAsync(id);
            if (view_seguimiento_denuncias == null)
            {
                return HttpNotFound();
            }
            return View(view_seguimiento_denuncias);
        }

        // GET: SeguimientoDenuncias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeguimientoDenuncias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CedulaDenunciante,Establecimiento,Producto,Estado,Status,Usuario,Perfil,FechaCreacion,Activo,UltModifFecha,UltModifUsuarioID,RegistroSanitario")] View_seguimiento_denuncias view_seguimiento_denuncias)
        {
            if (ModelState.IsValid)
            {
                db.View_seguimiento_denuncias.Add(view_seguimiento_denuncias);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(view_seguimiento_denuncias);
        }

        // GET: SeguimientoDenuncias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_seguimiento_denuncias view_seguimiento_denuncias = await db.View_seguimiento_denuncias.FindAsync(id);
            if (view_seguimiento_denuncias == null)
            {
                return HttpNotFound();
            }
            return View(view_seguimiento_denuncias);
        }

        // POST: SeguimientoDenuncias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CedulaDenunciante,Establecimiento,Producto,Estado,Status,Usuario,Perfil,FechaCreacion,Activo,UltModifFecha,UltModifUsuarioID,RegistroSanitario")] View_seguimiento_denuncias view_seguimiento_denuncias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(view_seguimiento_denuncias).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(view_seguimiento_denuncias);
        }

        // GET: SeguimientoDenuncias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_seguimiento_denuncias view_seguimiento_denuncias = await db.View_seguimiento_denuncias.FindAsync(id);
            if (view_seguimiento_denuncias == null)
            {
                return HttpNotFound();
            }
            return View(view_seguimiento_denuncias);
        }

        // POST: SeguimientoDenuncias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            View_seguimiento_denuncias view_seguimiento_denuncias = await db.View_seguimiento_denuncias.FindAsync(id);
            db.View_seguimiento_denuncias.Remove(view_seguimiento_denuncias);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        public ActionResult Panel(int? id)
        {
            if (id != null)
            {
                // var DenunciaInfo = db.tbl_denuncias.Where(d=>d.Id == id).Include();

                var DenunciaInfo = db.View_seguimiento_denuncias.Where(d => d.Id == id).ToList();//db.tbl_seguimiento_denuncias.Include(t => t.tbl_comentarios_denuncias).Include(t => t.tbl_denuncias).Include(t => t.tbl_usuarios).Include(t => t.tbl_status_denuncias).Where(d=>d.DenunciaID == id);

                ViewBag.DenunciaArray = DenunciaInfo;

                return View(DenunciaInfo);


            }
            else
            {
                return View();
            }


        }



        public async Task<ActionResult> DenunciasRecibidas()
        {

            var DenunciasRecibidas = db.View_denuncias_recibidas.ToListAsync();
            return View(await DenunciasRecibidas);

        }

        public async Task<ActionResult> DenunciasFalladas()
        {

            var DenunciasFalladas = db.View_denuncias_falladas.ToListAsync();
            return View(await DenunciasFalladas);

        }


        public async Task<ActionResult> DenunciasFinalizadas()
        {

            var DenunciasFinalizadas = db.View_denuncias_finalizadas.ToListAsync();
            return View(await DenunciasFinalizadas);

        }

        public async Task<ActionResult> DenunciasInvestigacion()
        {

            var DenunciasInvestigacion = db.View_denuncias_investigacion.ToListAsync();
            return View(await DenunciasInvestigacion);

        }

        public ActionResult GetEvidencias(int? DenunciaID)
        {

            var ListadoEvidencias = db.tbl_evidencias_denuncias.Select(e => e.ImagenDenuncia).ToList();

            return Json(ListadoEvidencias, JsonRequestBehavior.AllowGet);

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
