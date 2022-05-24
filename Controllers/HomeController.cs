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
    public class HomeController : Controller
    {
        
            [HttpGet]
            public IActionResult Index()
            {
                return View("Index");
            }

            [HttpGet]
            public IActionResult Details(int id)
            {
                using(webapp_travel_agencyContext db = new webapp_travel_agencyContext())
                {
                    try
                    {
                        PacchettoViaggio PackFound = db.PacchettoViaggio
                            .Where(x => x.Id == id)
                            .Single();  //tanto gli ID non si ripetono!
                        return View("Details", PackFound);
                    }
                    catch (InvalidOperationException ex)
                    {
                        return NotFound("Il pacchetto " + id + " non è presente.");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }


            [HttpGet]
            public IActionResult Privacy()
            {
                return View();
            }

        


























/*


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


*/


    }
}