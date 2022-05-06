using System.Collections.Generic;
using Bills.Models;
using Bills.Services;
using Bills.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{
    public class Sales_ReportController : Controller
    {
        IItemDetailsRepository itemDServices;
        

        public Sales_ReportController(IItemDetailsRepository itemDRepo)//inject 
        {
            itemDServices = itemDRepo;
            
        }
        public IActionResult Index()
        {
            return View(new SalesReport());
        }
        public IActionResult GetData(SalesReport report)
        {
            List<SalesDetalis> details =itemDServices.GetByDate(report.startDate, report.endDate);
            ViewData["tableData"] = details;
            return View("Index",new SalesReport());
        }
    }
}
