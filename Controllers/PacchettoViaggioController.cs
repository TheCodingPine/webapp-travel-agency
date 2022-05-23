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

        /*----------------------------------------------------------------------------------------------------------------------------*/

        [HttpGet]
        public IActionResult Details(int id)
        {


            using (webapp_travel_agencyContext db = new webapp_travel_agencyContext())
            {
                try
                {
                    PacchettoViaggio viaggioFound = db.PacchettoViaggio
                        //https://www.entityframeworktutorial.net/querying-entity-graph-in-entity-framework.aspx
                        .Where(x => x.Id == id)
                        .First();
                    return View("Details", viaggioFound);
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Pacchetto inesistente");
                }

            }
        }

        /*----------------------------------------------------------------------------------------------------------------------------*/

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (webapp_travel_agencyContext db = new webapp_travel_agencyContext())
            {
                try
                {
                    PacchettoViaggio pacchettoViaggio = db.PacchettoViaggio
                        .Where(x => x.Id == id)
                        .First();
                    return View("Edit", pacchettoViaggio);
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Non esiste il pacchetto " + id + ". E' fisicamente un pacchetto?");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PacchettoViaggio model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            PacchettoViaggio PackDaModificare = null;

            using (webapp_travel_agencyContext db = new webapp_travel_agencyContext())
            {
                PackDaModificare = db.PacchettoViaggio
                    .Where(viaggio => viaggio.Id == id)
                    .First();

                if (PackDaModificare == null)
                {
                    return NotFound("Il pacchetto viaggio non è fisicamente un pacchetto");
                }
                else
                {
                    PackDaModificare.NomePacchetto = model.NomePacchetto;
                    PackDaModificare.Descrizione = model.Descrizione;
                    PackDaModificare.Prezzo = model.Prezzo;
                    PackDaModificare.UrlImmagine = model.UrlImmagine;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
        }







    }
}
