using Bills.Data;
using Bills.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bills.Services
{
    //CRUD DEpartment Model
    public class ClientRepository: IClientRepository //: IRepostor<Department>// 
    {
        BillsDBcontext context;// = new ITIEntity();
        public ClientRepository(BillsDBcontext _context)
        {
            context = _context;
        }
        public Client GetByName(string NAme)
        {
            Client comp = context.Client.Where(s => s.Name == NAme).FirstOrDefault();
            return comp;
        }
        public List<Client> GetAll()
        {
            List<Client> compList = context.Client.ToList();
            return compList;
        }

        public Client GetById(int id)
        {
            Client dept = context.Client.FirstOrDefault(s => s.Id == id);
            return dept;
        }

        public int Insert(Client dept)
        {
            context.Client.Add(dept);
            int raws = context.SaveChanges();
            return raws;
        }
        public int GetNumber()
        {
            int number = int.Parse(context.Client
                            .OrderByDescending(p => p.Number)
                            .Select(r => r.Number)
                            .First().ToString());
            return number;
        }

    }
}
