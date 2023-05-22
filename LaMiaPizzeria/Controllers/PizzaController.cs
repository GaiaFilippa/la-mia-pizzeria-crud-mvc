using LaMiaPizzeria.Database;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    [Authorize]
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


        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Create(Pizza newPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newPizza);
            }

            using (PizzaContext db = new PizzaContext())
            {
                db.Pizze.Add(newPizza);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

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


        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Update(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza? pizzaToModify = db.Pizze.Where(article => article.Id == id).FirstOrDefault();

                if (pizzaToModify != null)
                {
                    return View("Update", pizzaToModify);
                }
                else
                {

                    return NotFound("L'articolo che vorresti modificare è inesistente!");
                }
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Update(int id, Pizza modifiedArticle)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", modifiedArticle);
            }

            using (PizzaContext db = new PizzaContext())
            {
                Pizza? articleToModify = db.Pizze.Where(article => article.Id == id).FirstOrDefault();

                if (articleToModify != null)
                {

                    articleToModify.Name = modifiedArticle.Name;
                    articleToModify.Description = modifiedArticle.Description;
                    articleToModify.Image = modifiedArticle.Image;
                    articleToModify.Price = modifiedArticle.Price;

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound("L'articolo che vorresti modificare è inesistente!");
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza? pizzaToDelete = db.Pizze.Where(article => article.Id == id).FirstOrDefault();

                if (pizzaToDelete != null)
                {
                    db.Remove(pizzaToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound("Non ho trovato l'articolo da eliminare!");

                }
            }
        }



    }
}



