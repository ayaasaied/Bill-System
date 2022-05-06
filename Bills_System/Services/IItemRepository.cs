using System.Collections.Generic;
using Bills.Models;

namespace Bills.Services
{
    public interface IItemRepository
    {
        public int Update(int id, Item item);
        List<Item> GetAll();
        Item GetById(int id);
        int Insert(Item dept);
        Item GetByName(string NAme);
        public List<Item> GetItemsInSpaceficType(int id);

    }
}