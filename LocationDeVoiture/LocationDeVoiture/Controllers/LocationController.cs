using LocationDeVoiture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocationDeVoiture.Controllers
{
    public class LocationController : Controller
    {

        LocationVoitureEntities db = new LocationVoitureEntities();
        // GET: Location
        public ActionResult Index()
        {
            var result = (from r in db.locations
                          join c in db.voitures on r.matricule equals c.matricule
                          select new LocationViewModel
                          {
                              matricule = r.matricule,
                              idclient = r.idclient,
                              prix = r.prix,
                              date_debut = r.date_debut,
                              date_fin = r.date_fin,
                              disponible = c.disponible,
                          }).ToList();



            return View(result);
        }


        [HttpGet]
        public ActionResult Getcar()
        {
            var voiture = db.voitures.ToList();
            return Json(voiture, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Getid(int id)
        {
            var client = (from s in db.clients where s.idclient == id select s.nom).ToList();
            return Json(client, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Getdisponible(string matricule)
        {
            var voituredispo = (from s in db.voitures where s.matricule == matricule select s.disponible).FirstOrDefault();
            return Json(voituredispo, JsonRequestBehavior.AllowGet);
        }









        [HttpPost]
        public ActionResult Sauvegarder(location louer)
        {
            if (ModelState.IsValid)
            {
                db.locations.Add(louer);

                voiture voiture = db.voitures.SingleOrDefault(e => e.matricule == louer.matricule);
                if(voiture == null)
                    return HttpNotFound("Matricule invalide !");

                voiture.disponible = "no";
                db.Entry(voiture).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(louer);
        }


    }
}