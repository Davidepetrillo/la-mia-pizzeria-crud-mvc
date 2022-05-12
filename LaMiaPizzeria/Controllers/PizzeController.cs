using LaMiaPizzeria.Models;
using LaMiaPizzeria.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    public class PizzeController : Controller
    {
        [HttpGet]
        public IActionResult Index(string nome, string descrizione, string prezzo, string immagine)
        {
            List<Pizze> pizze = PizzeData.GetPizze();

            return View("HomePage", pizze);
        }

        [HttpGet]

        public IActionResult Details(int id)
        {
            Pizze pizzaTrovata = null;
            foreach(Pizze pizza in PizzeData.GetPizze())
            {
                if(pizza.Id == id)
                {
                    pizzaTrovata = pizza;
                    break;
                }
            }
            if(pizzaTrovata != null)
            {
                return View("Details", pizzaTrovata);
            } else
            {
                return NotFound("La pizza con l'id " + id + "non è stato trovato");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizze nuovaPizza)
        {
            if(!ModelState.IsValid){
                return View("ErrorePizza");
            }
            PizzeData.GetPizze().Add(nuovaPizza);
        }
    }

}
