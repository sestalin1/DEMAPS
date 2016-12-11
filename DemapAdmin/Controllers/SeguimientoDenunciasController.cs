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
            var tbl_seguimiento_denuncias = db.tbl_seguimiento_denuncias.Include(t => t.tbl_comentarios_denuncias).Include(t => t.tbl_denuncias).Include(t => t.tbl_usuarios).Include(t => t.tbl_status_denuncias);
            return View(await tbl_seguimiento_denuncias.ToListAsync());
        }

        // GET: SeguimientoDenuncias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_seguimiento_denuncias tbl_seguimiento_denuncias = await db.tbl_seguimiento_denuncias.FindAsync(id);
            if (tbl_seguimiento_denuncias == null)
            {
                return HttpNotFound();
            }
            return View(tbl_seguimiento_denuncias);
        }

        // GET: SeguimientoDenuncias/Create
        public ActionResult Create()
        {
            ViewBag.ComentarioID = new SelectList(db.tbl_comentarios_denuncias, "Id", "Comentario");
            ViewBag.DenunciaID = new SelectList(db.tbl_denuncias, "Id", "CedulaDenunciante");
            ViewBag.AsignadaUsuarioID = new SelectList(db.tbl_usuarios, "Id", "Nombre");
            ViewBag.StatusDenunciaID = new SelectList(db.tbl_status_denuncias, "Id", "Status");
            return View();
        }

        // POST: SeguimientoDenuncias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DenunciaID,ComentarioID,AsignadaUsuarioID,StatusDenunciaID,FechaCreacion,CreadoPorUsuarioID,UltModifFecha,UltModifUsuarioID,Activo")] tbl_seguimiento_denuncias tbl_seguimiento_denuncias)
        {
            if (ModelState.IsValid)
            {
                db.tbl_seguimiento_denuncias.Add(tbl_seguimiento_denuncias);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ComentarioID = new SelectList(db.tbl_comentarios_denuncias, "Id", "Comentario", tbl_seguimiento_denuncias.ComentarioID);
            ViewBag.DenunciaID = new SelectList(db.tbl_denuncias, "Id", "CedulaDenunciante", tbl_seguimiento_denuncias.DenunciaID);
            ViewBag.AsignadaUsuarioID = new SelectList(db.tbl_usuarios, "Id", "Nombre", tbl_seguimiento_denuncias.AsignadaUsuarioID);
            ViewBag.StatusDenunciaID = new SelectList(db.tbl_status_denuncias, "Id", "Status", tbl_seguimiento_denuncias.StatusDenunciaID);
            return View(tbl_seguimiento_denuncias);
        }

        // GET: SeguimientoDenuncias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_seguimiento_denuncias tbl_seguimiento_denuncias = await db.tbl_seguimiento_denuncias.FindAsync(id);
            if (tbl_seguimiento_denuncias == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComentarioID = new SelectList(db.tbl_comentarios_denuncias, "Id", "Comentario", tbl_seguimiento_denuncias.ComentarioID);
            ViewBag.DenunciaID = new SelectList(db.tbl_denuncias, "Id", "CedulaDenunciante", tbl_seguimiento_denuncias.DenunciaID);
            ViewBag.AsignadaUsuarioID = new SelectList(db.tbl_usuarios, "Id", "Nombre", tbl_seguimiento_denuncias.AsignadaUsuarioID);
            ViewBag.StatusDenunciaID = new SelectList(db.tbl_status_denuncias, "Id", "Status", tbl_seguimiento_denuncias.StatusDenunciaID);
            return View(tbl_seguimiento_denuncias);
        }

        // POST: SeguimientoDenuncias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DenunciaID,ComentarioID,AsignadaUsuarioID,StatusDenunciaID,FechaCreacion,CreadoPorUsuarioID,UltModifFecha,UltModifUsuarioID,Activo")] tbl_seguimiento_denuncias tbl_seguimiento_denuncias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_seguimiento_denuncias).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ComentarioID = new SelectList(db.tbl_comentarios_denuncias, "Id", "Comentario", tbl_seguimiento_denuncias.ComentarioID);
            ViewBag.DenunciaID = new SelectList(db.tbl_denuncias, "Id", "CedulaDenunciante", tbl_seguimiento_denuncias.DenunciaID);
            ViewBag.AsignadaUsuarioID = new SelectList(db.tbl_usuarios, "Id", "Nombre", tbl_seguimiento_denuncias.AsignadaUsuarioID);
            ViewBag.StatusDenunciaID = new SelectList(db.tbl_status_denuncias, "Id", "Status", tbl_seguimiento_denuncias.StatusDenunciaID);
            return View(tbl_seguimiento_denuncias);
        }

    


        public ActionResult Panel(int ? id)
        {
            if (id != null)
            {
                // var DenunciaInfo = db.tbl_denuncias.Where(d=>d.Id == id).Include();

                var DenunciaInfo = db.View_seguimiento_denuncias.Where(d=>d.Id == id).ToList();//db.tbl_seguimiento_denuncias.Include(t => t.tbl_comentarios_denuncias).Include(t => t.tbl_denuncias).Include(t => t.tbl_usuarios).Include(t => t.tbl_status_denuncias).Where(d=>d.DenunciaID == id);

                ViewBag.DenunciaArray = DenunciaInfo;

                return View(DenunciaInfo);

 
            }
            else
            {
                return View();
            }
            
          
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
