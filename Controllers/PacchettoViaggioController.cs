using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class PacchettoViaggioController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            List<PacchettoViaggio> elencoViaggi = new List<PacchettoViaggio>();

            using (webapp_travel_agencyContext db = new webapp_travel_agencyContext())
            {
                elencoViaggi = db.PacchettoViaggio.ToList<PacchettoViaggio>();
            }
            return View(elencoViaggi);
        }

        /*----------------------------------------------------------------------------------------------------------------------------*/


        [HttpGet]
        public IActionResult Create()
        {
            PacchettoViaggio model = new PacchettoViaggio();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PacchettoViaggio data)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }

            using (webapp_travel_agencyContext db = new webapp_travel_agencyContext())
            {
                PacchettoViaggio nuovoViaggio = new PacchettoViaggio();
                nuovoViaggio.NomePacchetto = data.NomePacchetto;
                nuovoViaggio.Descrizione = data.Descrizione;
                nuovoViaggio.Prezzo = data.Prezzo;
                nuovoViaggio.UrlImmagine = data.UrlImmagine;

                db.Add(nuovoViaggio);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }













    }
}
