using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyRepository compServices;

        public CompanyController( ICompanyRepository compRepo)
        {
            compServices = compRepo;
        }
        public IActionResult uniquename(string name)
        {
            Company company = compServices.GetByName(name);
            if (company == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public IActionResult addcompany()
        {
            Company com = new Company();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult saveaddcompany(Company com)
        {
            if (ModelState.IsValid == true)
            {
                {
                    compServices.Insert(com);
                    return RedirectToAction("addcompany");
                }
            }

            return View("addcompany", com);
        }
    }
}
