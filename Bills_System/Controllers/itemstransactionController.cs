using Bills.Data;
using Bills.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Transactions;

namespace Bills.Controllers
{
    public class itemstransactionController : Controller
    {
        BillsDBcontext context = new BillsDBcontext();
        public IActionResult itemstrans()
        {
            List<Item> items = context.Item.ToList();
            ViewData["itms"] = items;
            return View();
        }
        [HttpPost]
        public IActionResult itemstrans(int itemid)
        {
            Item item  = context.Item.Where(x => x.Id == itemid).FirstOrDefault();
            List<SalesDetalis> sDetails  = context.SalesDetalis.Include(x=>x.I).Include(x => x.S).Where(x => x.Item_Id == itemid).ToList();
            ViewData["tableItem"] = item;
            ViewData["tablesDetails"] = sDetails;

            List<Item> items = context.Item.ToList();
            ViewData["itms"] = items;
            return View("itemstrans",context.Item.FirstOrDefault(s=>s.Id==itemid));
        }
        
    }
}
