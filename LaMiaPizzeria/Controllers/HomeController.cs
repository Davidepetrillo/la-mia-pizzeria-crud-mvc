using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LaMiaPizzeria.Controllers
{
    public class HomeController : Controller
    {
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

        public IActionResult PizzaPesto()
        {
            return View();
        }

        public IActionResult PizzaMargherita()
        {
            return View();
        }

        public IActionResult PizzaCrudaiola()
        {
            return View();
        }

        public IActionResult PizzaVegetariana()
        {
            return View();
        }

        public IActionResult PizzaFantasia()
        {
            return View();
        }

        public IActionResult PizzaQuattroStagioni()
        {
            return View();
        }

        public IActionResult PizzaTonnoCipolle()
        {
            return View();
        }

        public IActionResult PizzaPepperoni()
        {
            return View();
        }

        public IActionResult PizzaPrimavera()
        {
            return View();
        }

        public IActionResult PizzaOrtolana()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}