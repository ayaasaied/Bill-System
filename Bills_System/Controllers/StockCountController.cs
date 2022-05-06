
using System.Collections.Generic;
using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{
    public class StockCountController : Controller
    {
        IItemRepository itemServices;
        ICompanyRepository compServices;
        ITypeRepository typeServices;
        IUnitRepository unitServices;

        public StockCountController(IItemRepository itemRepo, ICompanyRepository compRepo, ITypeRepository typeRepo, IUnitRepository unitRepo)//inject 
        {
            itemServices = itemRepo;
            compServices = compRepo;
            typeServices = typeRepo;
            unitServices = unitRepo;

        }
        public IActionResult stockscount()
        {
            List<Type> types = typeServices.GetAll();
            ViewData["types"] = types;
            return View(new Item());
        }


        [HttpPost]
        public IActionResult stockscount(int typeId)
        {
            List<Item> items = itemServices.GetItemsInSpaceficType(typeId);
            
            List<Type> types = typeServices.GetAll();
            ViewData["types"] = types;
            ViewData["items"] = items;

            return View("stockscount", itemServices.GetById(typeId));
        }
    }
}
