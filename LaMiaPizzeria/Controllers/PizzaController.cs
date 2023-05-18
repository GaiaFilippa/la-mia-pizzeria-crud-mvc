using LaMiaPizzeria.Database;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizze = db.Pizze.ToList();
                return View(pizze);
            }
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }






        public IActionResult Details(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza? pizzaDetails = db.Pizze.Where(pizze => pizze.Id == id).FirstOrDefault();

                if (pizzaDetails != null)
                {
                    return View("Details", pizzaDetails);
                }
                else
                {
                    return NotFound($"L'articolo con id {id} non è stato trovato!");
                }
            }

        }

    }
}
