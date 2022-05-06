using Bills.Data;
using Bills.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bills.Services
{
    //CRUD DEpartment Model
    public class CompanyRepository: ICompanyRepository //: IRepostor<Department>// 
    {
        BillsDBcontext context;// = new ITIEntity();
        public CompanyRepository(BillsDBcontext _context)
        {
            context = _context;
        }
        public Company GetByName(string NAme)
        {
            Company comp = context.Company.Where(s => s.Name == NAme).FirstOrDefault();
            return comp;
        }
        public List<Company> GetAll()
        {
            List<Company> compList = context.Company.ToList();
            return compList;
        }

        public Company GetById(int id)
        {
            Company dept = context.Company.FirstOrDefault(s => s.Id == id);
            return dept;
        }

        public int Insert(Company dept)
        {
            context.Company.Add(dept);
            int raws = context.SaveChanges();
            return raws;
        }
        
    }
}
