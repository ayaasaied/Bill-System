using System.Collections.Generic;
using Bills.Models;

namespace Bills.Services
{
    public interface IClientRepository
    {
        //int Delete(int id);
        public int GetNumber();
        List<Client> GetAll();
        Client GetById(int id);
        int Insert(Client dept);
        public Client GetByName(string NAme);

       // int Update(int id, Company compEdit);
    }
}