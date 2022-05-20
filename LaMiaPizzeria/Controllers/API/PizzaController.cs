using LaMiaPizzeria.Data;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {
            List<Pizze> pizze = new List<Pizze>();

            using (PizzeContext db = new PizzeContext())
            {
                if (search != null && search != "")
                {
                    pizze = db.Pizze.Where(pizze => pizze.Nome.Contains(search) || pizze.Descrizione.Contains(search)).ToList<Pizze>();
                }
                else
                {
                    pizze = db.Pizze?.ToList<Pizze>();
                }
            }

            return Ok(pizze);
        }

    }
}
