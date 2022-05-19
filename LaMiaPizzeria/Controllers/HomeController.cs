using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LaMiaPizzeria.Controllers
{
    public class HomeController : Controller
    {       
        public IActionResult Index()
        {
            return View("Index");
        }

    }
}