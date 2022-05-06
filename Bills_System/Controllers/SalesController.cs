using System.Collections.Generic;
using System.Linq;
using Bills.Data;
using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bills.Controllers
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class SalesController : Controller
    {
        IItemRepository itemServices;
        IItemDetailsRepository itemDetailsServices;
        ISalesRepository salesServices;
        IClientRepository clientServices;

        public SalesController(ISalesRepository salesRepo,IItemRepository itemRepo,IClientRepository clientRepo, IItemDetailsRepository itemDetailsRepo)
        {
            itemServices = itemRepo;
            clientServices = clientRepo;
            itemDetailsServices = itemDetailsRepo;
            salesServices = salesRepo;
        }
        public IActionResult TestPaied(float paied,float total, float disvalue)
        {
            if (paied <= (total- disvalue))
            {
                return Json(true);
            }

            return Json(false);
        }
        public IActionResult SaveItem(SalesDetalis item)
        {

            
            List<SalesDetalis> objsComplex = new List<SalesDetalis>();
            List<Item> itemsforTable = new List<Item>();         
            List<float> totals = new List<float>();

            float total = 0;
            if (ModelState.IsValid)
            {
                
                SalesDetalis objComplex = new SalesDetalis();
                
                for (int i = 0; i < 10; i++)
                {
                    objComplex = HttpContext.Session.GetObject<SalesDetalis>($"ComplexObject{i}");
                    if (objComplex == null)
                    {
                        
                        HttpContext.Session.SetObject($"ComplexObject{i}", item);
                        
                        objComplex = HttpContext.Session.GetObject<SalesDetalis>($"ComplexObject{i}");
                        objsComplex.Add(objComplex);
                        
                        itemsforTable.Add(itemServices.GetById(objComplex.Item_Id));
                        total += objComplex.Price * objComplex.quantity;
                        totals.Add(objComplex.Price * objComplex.quantity);

                        ViewData["allTotals"] = totals;
                        ViewData["MoreDetailsTableItem"] = itemsforTable;
                       
                        ViewData["TableItems"] = objsComplex;
                        ViewData["total"] = total;
                        ViewData["clients"] = clientServices.GetAll();
                        ViewData["items"] = itemServices.GetAll();
                        
                        return View("NewBill", new Sales());
                    }
                    
                    total += objComplex.Price * objComplex.quantity;
                    objsComplex.Add(objComplex);
                    itemsforTable.Add(itemServices.GetById(objComplex.Item_Id));
                    totals.Add(objComplex.Price * objComplex.quantity);



                }

            }
            ViewData["total"] = total;
            ViewData["clients"] = clientServices.GetAll();
            ViewData["items"] = itemServices.GetAll();
            return View("NewBill", new Sales());
        }

        public IActionResult ItemPriceDetails(int item_id)
        {
            Item item = itemServices.GetById(item_id);
            ViewData["item"] = item;
            return PartialView("_ItemPrice",item);
        }
        public IActionResult NewBill()
        {
            ViewData["clients"]= clientServices.GetAll();
            ViewData["items"] = itemServices.GetAll();
            ViewData["item"] = new SalesDetalis();
            return View(new Sales());
        }
        public IActionResult GenerateSalesNumber()
        {
            int number = salesServices.GetNumber();
                
            if (number == null)
                ViewData["number"] = 1;

            ViewData["number"] = ++number;
            
            return PartialView("_PartialGenerateSalesNumber");

        }

        public IActionResult saveBill(Sales sales)
        {
            if (ModelState.IsValid)
            {
                
                List<SalesDetalis> objsComplex = new List<SalesDetalis>();
                SalesDetalis objComplex = new SalesDetalis();
                for (int i = 0; i < 10; i++)
                {
                    objComplex = HttpContext.Session.GetObject<SalesDetalis>($"ComplexObject{i}");
                    if (objComplex != null)
                    {
                        objsComplex.Add(HttpContext.Session.GetObject<SalesDetalis>($"ComplexObject{i}"));
                        HttpContext.Session.SetObject($"ComplexObject{i}", null);
                        continue;
                    }
                    else
                    {
                        break;
                    }
                    
                }

                salesServices.Insert(sales);
                int sales_id = salesServices.GetSalesId();
                foreach (SalesDetalis i in objsComplex)
                {
                    i.Sales_Id = sales_id;
                    itemDetailsServices.Insert(i);
                    Item it= itemServices.GetById(i.Item_Id);
                    it.Stock -= i.quantity;
                    itemServices.Update(it.Id, it);

                }
                return RedirectToAction("NewBill");
            }
            ViewData["clients"] = clientServices.GetAll();
            ViewData["items"] = itemServices.GetAll();
            return View("NewBill", sales);
        }
        public IActionResult TestQuantity(int quantity, int Item_Id)
        {
            Item item = itemServices.GetById(Item_Id);
            if (item.Stock>quantity)
            {
                return Json(true);
            }
            else
                return Json(false);
        }
    }
}
