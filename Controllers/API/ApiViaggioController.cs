using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapp_travel_agency.Controllers.API
{
    
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class ApiViaggioController : ControllerBase
        {
            [HttpGet]  
            public IActionResult Get(string? cerca, int? id)
            {
                List<PacchettoViaggio> listaViaggiApi = new List<PacchettoViaggio>();

                using (webapp_travel_agencyContext db = new webapp_travel_agencyContext())
            {
                    if (cerca != null)
                    {
                        listaViaggiApi = db.PacchettoViaggio
                            /*Un'espressione lambda è una funzione anonima che è possibile utilizzare per creare delegati o tipi di albero di espressioni.
                             * Utilizzando espressioni lambda, è possibile scrivere funzioni locali
                                Metti tutti i parametri sul lato sinistro dell'operatore.
                            Sul lato destro, metti un'espressione che può usare quei parametri; questa espressione si risolverà come valore di ritorno della funzione.
                            Più raramente, se necessario, un intero {code block} può essere utilizzato sul lato destro.
                            Se il tipo di reso non è nullo, il blocco conterrà un'istruzione di reso.*/
                            .Where(viaggio => viaggio.NomePacchetto.Contains(cerca) || viaggio.Descrizione.Contains(cerca))
                            //tldr, dato viaggio, 
                            .ToList();
                        return Ok(listaViaggiApi); //non più una view ma un contenuto. code200 con body
                    }
                    else if (id != null)
                    {
                        PacchettoViaggio PackDetails = db.PacchettoViaggio
                            .Where(viaggio => viaggio.Id == id)
                            .Single(); //meglio di First, l'ID è univoco
                        return Ok(PackDetails);
                    }
                    else
                    { 
                        return Ok(db.PacchettoViaggio.ToList());//restituiti come JSON con code 200 in body
                    }
                }
            }
        }
    
}
