using Bills.Data;
using Bills.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bills.Services
{
    //CRUD DEpartment Model
    public class ItemDetailsRepository: IItemDetailsRepository //: IRepostor<Department>// 
    {
        BillsDBcontext context;// = new ITIEntity();
        public ItemDetailsRepository(BillsDBcontext _context)
        {
            context = _context;
        }
        //public SalesDetalis GetByName(string NAme)
        //{
        //    SalesDetalis comp = context.SalesDetalis.Where(s => s.Name == NAme).FirstOrDefault();
        //    return comp;
        //}
        public List<SalesDetalis> GetAll()
        {
            List<SalesDetalis> itemdetailsList = context.SalesDetalis.ToList();
            return itemdetailsList;
        }

        public SalesDetalis GetById(int id)
        {
            SalesDetalis itemdetails = context.SalesDetalis.Include(s => s.I).Include(s => s.I.Unit).FirstOrDefault(s => s.Id == id);
            return itemdetails;
        }
        public List<SalesDetalis> GetByDate(DateTime startDate, DateTime endDate)
        {
            List<SalesDetalis> itemdetails = context.SalesDetalis.Include(s => s.I).Include(s => s.S).Include(s=>s.S.Client).Where(s => (s.S.Date >= startDate && s.S.Date<= endDate)).ToList();
            List<SalesDetalis> result = itemdetails.GroupBy(test => test.Sales_Id)
                   .Select(grp => grp.First())
                   .ToList();
            return result;
        }

        public int Insert(SalesDetalis itemdetails)
        {
            context.SalesDetalis.Add(itemdetails);
            int raws = context.SaveChanges();
            return raws;
        }
        
    }
}
