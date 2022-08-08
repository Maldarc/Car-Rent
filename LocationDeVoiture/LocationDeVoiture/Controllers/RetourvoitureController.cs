using LocationDeVoiture.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocationDeVoiture.Controllers
{

    public class RetourvoitureController : Controller
    {
        LocationVoitureEntities db = new LocationVoitureEntities();
        // GET: Retourvoiture
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sauvegarder(retourvoiture revoiture)
        {
            if(ModelState.IsValid)
            {
                db.retourvoitures.Add(revoiture);

                var voiture = db.voitures.SingleOrDefault(e => e.matricule == revoiture.matricule);
                
                if(voiture == null)
                    return HttpNotFound("Voiture introuvable !");
                voiture.disponible = "oui";
                db.Entry(voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(revoiture);
        }



        [HttpPost]
        public ActionResult Getmatricule(string matricule)
        {
            var voiture = (from s in db.locations
                           where s.matricule == matricule
                           select new
                           {
                               DateDebut = s.date_debut,
                               DateFin = s.date_fin,
                               IDclient = s.idclient,
                               matricule = s.matricule,
                               prix = s.prix,
                               NombreJours = SqlFunctions.DateDiff("day", s.date_fin, DateTime.Now)
                           }).ToArray();
            return Json(voiture, JsonRequestBehavior.AllowGet);
        }
    }
}