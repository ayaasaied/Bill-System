using System.Collections.Generic;
using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{
    public class TypeController : Controller
    {
        ICompanyRepository compServices;
        ITypeRepository typeServices;

        public TypeController(ICompanyRepository compRepo, ITypeRepository typeRepo)//inject 
        {
            compServices = compRepo;
            typeServices = typeRepo;

        }
        public IActionResult UniqueTypeName(string name)
        {
            Type type = typeServices.GetByName(name);
            if (type == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public IActionResult AddType()
        {
            Type Newtype = new Type();
            List<Company> Companies = compServices.GetAll();
            ViewData["comp"] = Companies;
            return View(Newtype);
        }

        //When we press on Add button
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveType(Type Newtype)
        {
            if (ModelState.IsValid == true)
            {
                {
                    //save in Database
                    typeServices.Insert(Newtype);
                    return RedirectToAction("AddType");
                }
            }
            return View("AddType", Newtype);
        }
    }
}
