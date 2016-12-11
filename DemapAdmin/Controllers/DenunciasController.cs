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
    public class denunciasController : Controller
    {
        private DEMAPSEntities db = new DEMAPSEntities();

        // GET: denuncias
        public async Task<ActionResult> Index()
        {
            var tbl_denuncias = db.tbl_denuncias.Include(t => t.tbl_tipos_denuncias);
            return View(await tbl_denuncias.ToListAsync());
        }

        // GET: denuncias/Details/5
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


        // GET: denuncias/Edit/5
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
            ViewBag.TipoDenunciaID = new SelectList(db.tbl_tipos_denuncias, "Id", "Tipo", tbl_denuncias.TipoDenunciaID);
            return View(tbl_denuncias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TipoDenunciaID,CedulaDenunciante,Producto,Establecimiento,FechaCreacion,Activo")] tbl_denuncias tbl_denuncias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_denuncias).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TipoDenunciaID = new SelectList(db.tbl_tipos_denuncias, "Id", "Tipo", tbl_denuncias.TipoDenunciaID);
            return View(tbl_denuncias);
        }

        public async Task<ActionResult> DenunciasRecibidas()
        {
            /*  if (ValidateUserPermissionToModule("M_REMISION_EXP_PENDIENTES"))
              {*/
            //  var UserProfileOnline = (Dictionary<string, string>)Session["UserProfile"];
            // var SucursalID = Convert.ToInt32(UserProfileOnline["SucursalID"]);

            var DenunciasRecibidas = db.View_denuncias_recibidas.ToListAsync();
            return View(await DenunciasRecibidas);

            /*  }
              else
              {
                  return RedirectToAction("Index", "Login");
              }*/
        }

        public async Task<ActionResult> DenunciasFalladas()
        {
            /*  if (ValidateUserPermissionToModule("M_REMISION_EXP_PENDIENTES"))
              {*/
            //  var UserProfileOnline = (Dictionary<string, string>)Session["UserProfile"];
            // var SucursalID = Convert.ToInt32(UserProfileOnline["SucursalID"]);

            var DenunciasFalladas = db.View_denuncias_falladas.ToListAsync();
            return View(await DenunciasFalladas);

            /*  }
              else
              {
                  return RedirectToAction("Index", "Login");
              }*/
        }


        public async Task<ActionResult> DenunciasFinalizadas()
        {
            /*  if (ValidateUserPermissionToModule("M_REMISION_EXP_PENDIENTES"))
              {*/
            //  var UserProfileOnline = (Dictionary<string, string>)Session["UserProfile"];
            // var SucursalID = Convert.ToInt32(UserProfileOnline["SucursalID"]);

            var DenunciasFinalizadas = db.View_denuncias_finalizadas.ToListAsync();
            return View(await DenunciasFinalizadas);

            /*  }
              else
              {
                  return RedirectToAction("Index", "Login");
              }*/
        }

        public async Task<ActionResult> DenunciasInvestigacion()
        {
            /*  if (ValidateUserPermissionToModule("M_REMISION_EXP_PENDIENTES"))
              {*/
            //  var UserProfileOnline = (Dictionary<string, string>)Session["UserProfile"];
            // var SucursalID = Convert.ToInt32(UserProfileOnline["SucursalID"]);

            var DenunciasInvestigacion = db.View_denuncias_investigacion.ToListAsync();
            return View(await DenunciasInvestigacion);

            /*  }
              else
              {
                  return RedirectToAction("Index", "Login");
              }*/
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
