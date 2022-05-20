using LaMiaPizzeria.Data;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeria.Controllers
{
    public class PizzeController : Controller
    {
        [HttpGet]
        public IActionResult Index(string SearchString)
        {
            List<Pizze> pizze = new List<Pizze>();

            using (PizzeContext db = new PizzeContext())
            {
                if (SearchString != null)
                {
                    pizze = db.Pizze.Where(pizze => pizze.Nome.Contains(SearchString) || pizze.Descrizione.Contains(SearchString)).ToList<Pizze>();
                }
                else
                {
                    pizze = db.Pizze.ToList<Pizze>();
                }
            }

            return View("HomePage", pizze);
        }

        [HttpGet]

        public IActionResult Details(int id)
        {
            

            using (PizzeContext db = new PizzeContext())
            {
                try
                {
                    Pizze pizzaTrovata = db.Pizze
                             .Where(pizze => pizze.Id == id).Include(Pizze => Pizze.Category)
                             .FirstOrDefault();

                    return View("Details", pizzaTrovata);

                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("La pizza con id " + id + " non è stata trovata");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
        
        }

        [HttpGet]
        public IActionResult Create()
        {
            using (PizzeContext db = new PizzeContext())
            {
                List<Category> categorie = db.Category.ToList();

                PizzeCategorie model = new PizzeCategorie();
                model.Pizze = new Pizze();
                model.Categorie = categorie;
                return View("FormPizze", model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzeCategorie data)
        {
            if (!ModelState.IsValid)
            {

                using (PizzeContext db = new PizzeContext())
                {
                    List<Category> categorie = db.Category.ToList();
                    data.Categorie = categorie;
                }
                return View("FormPizze", data);
            }

            using (PizzeContext db = new PizzeContext())
            {
                Pizze nuovaPizza = new Pizze();
                nuovaPizza.Nome = data.Pizze.Nome;
                nuovaPizza.Descrizione = data.Pizze.Descrizione;
                nuovaPizza.Immagine = data.Pizze.Immagine;
                nuovaPizza.CategoryId = data.Pizze.CategoryId;

                db.Pizze.Add(nuovaPizza);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Pizze pizzaDaModificare = null;
            List<Category> categorie = new List<Category>();

            using (PizzeContext db = new PizzeContext())
            {
                pizzaDaModificare = db.Pizze.Where(pizze => pizze.Id == id).FirstOrDefault();
                
                categorie = db.Category.ToList<Category>();
            }

            if (pizzaDaModificare == null)
            {
                return NotFound();
            }
            else
            {
                PizzeCategorie model = new PizzeCategorie();
                model.Pizze = pizzaDaModificare;
                model.Categorie = categorie;
                return View("Update", model);
            }

        }

        [HttpPost]
        public IActionResult Update(int id, PizzeCategorie model)
        {
            if (!ModelState.IsValid)
            {

                using (PizzeContext db = new PizzeContext())
                {
                    List<Category> categorie = db.Category.ToList();
                    model.Categorie = categorie;
                }
                return View("Update", model);
            }

            Pizze pizzaDaModificare = null;

            using (PizzeContext db = new PizzeContext())
            {
                pizzaDaModificare = db.Pizze.Where(pizze => pizze.Id == id).FirstOrDefault();


                if (pizzaDaModificare != null)
                {
                    pizzaDaModificare.Nome = model.Pizze.Nome;
                    pizzaDaModificare.Descrizione = model.Pizze.Descrizione;
                    pizzaDaModificare.Immagine = model.Pizze.Immagine;
                    pizzaDaModificare.Prezzo = model.Pizze.Prezzo;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }

        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (PizzeContext db = new PizzeContext())
            {
                Pizze pizzaDaEliminare = db.Pizze.Where(pizze => pizze.Id == id).FirstOrDefault();

                if (pizzaDaEliminare != null)
                {
                    db.Pizze.Remove(pizzaDaEliminare);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Pizze");
                }
                else
                {
                    return NotFound();
                }
            }


        }

    }
}

