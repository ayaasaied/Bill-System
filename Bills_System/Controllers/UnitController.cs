using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{
    public class UnitController : Controller
    {
        
        IUnitRepository unitServices;

        public UnitController(IUnitRepository unitRepo)//inject 
        {
            
            unitServices = unitRepo;

        }
        public IActionResult uniquename(string name)
        {
            Unit unit = unitServices.GetByName(name);
            if (unit == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public IActionResult addunit()
        {
            Unit unit = new Unit();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult saveaddunit(Unit unit)
        {
            //unit.Item_Id = 1;
            if (ModelState.IsValid == true)
            {

                {
                    unitServices.Insert(unit);
                    return RedirectToAction("addunit");
                }

            }

            return View("addunit", unit);
        }
    }
}
