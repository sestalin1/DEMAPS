using DemapAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemapAdmin.Controllers
{
 
    public class HomeController : Controller
    {
        private DEMAPSEntities db = new DEMAPSEntities();

        public ActionResult Index()
        {
            GetTotalDenunciasPendientes();
            GetTotalDenunciasFalladas();
            GetTotalDenunciasFinalizadas();
            GetTotalDenunciasInvestigacion();
            TotalesPorTipoProducto();
            return View();
        }

        [HttpPost]
        public JsonResult GetTotalDenunciasPendientes()
        {

            var TotalPendientes = db.View_denuncias_recibidas.Count();
            ViewBag.TotalPendientes = TotalPendientes;
            return Json(TotalPendientes, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetTotalDenunciasFinalizadas()
        {

            var TotalFinalizadas = db.View_denuncias_finalizadas.Count();
            ViewBag.TotalFinalizadas = TotalFinalizadas;
            return Json(TotalFinalizadas, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetTotalDenunciasInvestigacion()
        {

            var TotalInvestigacion = db.View_denuncias_investigacion.Count();
            ViewBag.TotalInvestigacion = TotalInvestigacion;
            return Json(TotalInvestigacion, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetTotalDenunciasFalladas()
        {

            var totalFalladas = db.View_denuncias_falladas.Count();
            ViewBag.totalFalladas = totalFalladas;
            return Json(totalFalladas, JsonRequestBehavior.AllowGet);

        }

        public JsonResult TotalesPorTipoProducto()
        {

            var TotalAlimentos = db.View_denuncias.Where(a=>a.Tipo=="MEDICAMENTO").Count();
            var TotalMedicamentos = db.View_denuncias.Where(a => a.Tipo == "OTROS").Count();
            var TotalOtros = db.View_denuncias.Where(a => a.Tipo == "ALIMENTO").Count();

            ViewBag.TotalAlimentos = TotalAlimentos;
            ViewBag.TotalMedicamentos = TotalMedicamentos;
            ViewBag.TotalOtros = TotalOtros;

            return Json(TotalAlimentos, JsonRequestBehavior.AllowGet);

        }
    }
}