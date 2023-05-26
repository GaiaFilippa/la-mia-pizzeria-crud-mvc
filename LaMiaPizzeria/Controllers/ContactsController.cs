using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
