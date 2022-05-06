using System.Collections.Generic;
using Bills.Models;

namespace Bills.Services
{
    public interface ISalesRepository
    {
        //int Delete(int id);
        public int GetNumber();
        public int GetSalesId();
        List<Sales> GetAll();
        Sales GetById(int id);
        int Insert(Sales sale);
        //public Sales GetByName(string NAme);

       // int Update(int id, Company compEdit);
    }
}