using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{

    public class ClientController : Controller
    {
        IClientRepository clientServices;

        public ClientController(IClientRepository clientRepo)
        {
            clientServices = clientRepo;

        }
        public IActionResult New()
        {
            return View(new Client());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAdd(Client newClient)
        {
            if (ModelState.IsValid == true)
            {
                clientServices.Insert(newClient);
                return RedirectToAction("Index", "Home");
            }
            return View("New", newClient);
        }

        public IActionResult UniqueName(string name)
        {
            Client client = (Client)clientServices.GetByName(name);

            if (client == null)
            {
                return Json(true);
            }
            else
                return Json(false);
        }
        public IActionResult GenerateClientNumber()
        {
            int number = clientServices.GetNumber();

            if (number == null)
                ViewData["number"] = 1;

            ViewData["number"] = ++number;

            return PartialView("_PartialGenerateClientNumber");

        }
    }
}
