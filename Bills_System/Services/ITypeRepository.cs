using System.Collections.Generic;
using Bills.Models;

namespace Bills.Services
{
    public interface ITypeRepository
    {
        //int Delete(int id);
        public List<Type> GetAll(int com_id);
        public Type GetByName(string NAme);
        List<Type> GetAll();
        Type GetById(int id);
        int Insert(Type dept);
        //int Update(int id, Type deptEdit);
    }
}