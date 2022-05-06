
using System.Collections.Generic;
using System.Linq;
using Bills.Data;
using Bills.Models;
using Microsoft.EntityFrameworkCore;

namespace Bills.Services
{
    //CRUD DEpartment Model
    public class ItemRepository: IItemRepository //: IRepostor<Department>// 
    {
        BillsDBcontext context;// = new ITIEntity();
        public ItemRepository(BillsDBcontext _context)
        {
            context = _context;
        }
        public List<Item> GetAll()
        {
            List<Item> itemList = context.Item.ToList();
            return itemList;
        }
        

        public Item GetById(int id)
        {
            Item item = context.Item.Include(s => s.Unit).FirstOrDefault(s => s.Id == id);
            return item;
        }
        public Item GetByName(string NAme)
        {
            Item item = context.Item.Where(s => s.Name == NAme).FirstOrDefault();
            return item;
        }
        public List<Item> GetItemsInSpaceficType(int id)
        {
            List<Item> items = context.Item.Where(s => s.Type_Id == id).ToList();
            return items;
        }
        public int Insert(Item item)
        {
            context.Item.Add(item);
            int raws = context.SaveChanges();
            return raws;
        }
        public int Update(int id, Item item)
        {
            Item oldItem = context.Item.FirstOrDefault(s => s.Id == id);
            oldItem.Stock = item.Stock;
            

            int raws = context.SaveChanges();
            return raws;
        }

    }
}
