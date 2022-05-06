using System.Collections.Generic;
using Bills.Models;

namespace Bills.Services
{
    public interface ICompanyRepository
    {
        //int Delete(int id);
        List<Company> GetAll();
        Company GetById(int id);
        int Insert(Company dept);
        public Company GetByName(string NAme);

       // int Update(int id, Company compEdit);
    }
}