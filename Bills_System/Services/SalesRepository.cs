using Bills.Data;
using Bills.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bills.Services
{
    //CRUD DEpartment Model
    public class SalesRepository : ISalesRepository //: IRepostor<Department>// 
    {
        BillsDBcontext context;// = new ITIEntity();
        public SalesRepository(BillsDBcontext _context)
        {
            context = _context;
        }
        //public Sales GetByName(string NAme)
        //{
        //    Sales comp = context.Sales.Where(s => s.Name == NAme).FirstOrDefault();
        //    return comp;
        //}
        public List<Sales> GetAll()
        {
            List<Sales> salesList = context.Sales.ToList();
            return salesList;
        }
        public int GetNumber()
        {
            int number = int.Parse(context.Sales
                            .OrderByDescending(p => p.BillsNumber)
                            .Select(r => r.BillsNumber)
                            .First().ToString());
            return number;
        }
        public int GetSalesId()
        {
            int sales_id = context.Sales.OrderByDescending(s => s.Id).Select(s => s.Id).FirstOrDefault(); 
            return sales_id;
        }

        public Sales GetById(int id)
        {
            Sales dept = context.Sales.FirstOrDefault(s => s.Id == id);
            return dept;
        }

        public int Insert(Sales dept)
        {
            context.Sales.Add(dept);
            int raws = context.SaveChanges();
            return raws;
        }
        
    }
}
