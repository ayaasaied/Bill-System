using System;
using System.Collections.Generic;
using Bills.Models;

namespace Bills.Services
{
    public interface IItemDetailsRepository
    {
        //int Delete(int id);
        List<SalesDetalis> GetAll();
        SalesDetalis GetById(int id);
        int Insert(SalesDetalis dept);
        public List<SalesDetalis> GetByDate(DateTime startDate, DateTime endDate);
        //public SalesDetalis GetByName(string NAme);

        // int Update(int id, Company compEdit);
    }
}