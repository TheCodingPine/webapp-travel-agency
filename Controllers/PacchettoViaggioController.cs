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
/* --------------------------MAGIA NERA--------------------
        // GET: PacchettoViaggio
        public async Task<IActionResult> Index()
        {
              return _context.PacchettoViaggio != null ? 
                          View(await _context.PacchettoViaggio.ToListAsync()) :
                          Problem("Entity set 'webapp_travel_agencyContext.PacchettoViaggio'  is null.");
        }*/

        // GET: PacchettoViaggio/Details/5




        [HttpGet]
        public IActionResult Details(int Id)
        {
            PacchettoViaggio packTrovato = GetPostById(Id)

                if (packTrovato != null)
            {
                return View("Details", packTrovato);
            } else
            {
                return NotFound("Non esiste un PAcchetto con ID" + Id);
            }
        }







    }
}
