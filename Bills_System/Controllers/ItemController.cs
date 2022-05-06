using System.Collections.Generic;
using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{
    public class ItemController : Controller
    {
        IItemRepository itemServices;
        ICompanyRepository compServices;
        ITypeRepository typeServices;
        IUnitRepository unitServices;
        
        public ItemController(IItemRepository itemRepo, ICompanyRepository compRepo, ITypeRepository typeRepo, IUnitRepository unitRepo)//inject 
        {
            itemServices = itemRepo;
            compServices = compRepo;
            typeServices = typeRepo;
            unitServices = unitRepo;
            
        }
        public IActionResult TestPrice(int SellingPrice, int BuyingPrice)
        {
            //logic   
            if (BuyingPrice < SellingPrice)
            {
                return Json(true);
            }

            return Json(false);
        }
        public IActionResult TestItemName(string Name)
        {
            Item item = itemServices.GetByName(Name);
            if (item == null)
            {
                return Json(true);
            }
            else
                return Json(false);
        }
        [HttpGet]
        public IActionResult New()
        {
            List <Company> comp = compServices.GetAll();
            ViewData["comps"] = comp;
            
            List<Unit> unit = unitServices.GetAll();
            ViewData["units"] = unit;
            return View(new Item());
        }
        public IActionResult TypeDetails(int com_id)
        {
            List<Type> type = typeServices.GetAll(com_id);
            ViewData["types"] = type;
            return PartialView("_TypeSelect");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew(Item newItem)
        {
            if (ModelState.IsValid)
            {
                itemServices.Insert(newItem);
                return RedirectToAction("New");

            }
            return View("New", newItem);
        }

    }
}
