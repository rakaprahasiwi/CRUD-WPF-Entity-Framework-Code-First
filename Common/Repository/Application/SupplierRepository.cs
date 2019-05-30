using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.ViewModels;
using DataAccess.Context;
using System.Data.Entity;

namespace Common.Repository.Application
{
    //this is for throw data
    public class SupplierRepository : ISupplierRepository
    {
        MyContext myContext = new MyContext();
        //Suppliers supplier = new Suppliers();

        bool status = false;

        public bool Delete(int id)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Delete();
                myContext.Entry(get).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
        }

        public List<Suppliers> Get()
        {
            var get = myContext.Suppliers.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Suppliers Get(int id)
        {
            var get = myContext.Suppliers.Find(id);
            return get;
        }

        public List<Suppliers> GetSearch(string values)
        {
            var get = myContext.Suppliers.Where(x => (x.Name.Contains(values) || x.Id.ToString().Contains(values)) && x.IsDelete==false).ToList();
            return get;
        }

        public bool Insert(SupplierVM supplierVM)
        {
            var push = new Suppliers(supplierVM);
            myContext.Suppliers.Add(push);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
                return status;
            }
            else
            {
                return status;
            }

        }

        public bool Update(int id, SupplierVM supplierVM)
        {
            var get = Get(id);
            if(get != null)
            {
                get.Update(id, supplierVM);
                myContext.Entry(get).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
            
        }
    }
}
