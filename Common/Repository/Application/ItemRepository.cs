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
    public class ItemRepository : IItemRepository
    {
        MyContext myContext = new MyContext();

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

        public List<Item> Get()
        {
            var get = myContext.Item.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Item Get(int id)
        {
            var get = myContext.Item.Find(id);
            return get;
        }

        public List<Item> GetSearch(string values)
        {
            var get = myContext.Item.Where(x => (x.Name.Contains(values) || x.Id.ToString().Contains(values) || x.Stock.ToString().Contains(values) || x.Price.ToString().Contains(values) || x.Supplier_Id.ToString().Contains(values)) && x.IsDelete == false).ToList();
            return get;
        }

        public bool Insert(ItemVM itemVM)
        {
            var push = new Item(itemVM);
            var get = myContext.Suppliers.Find(itemVM.Supplier_Id);
            if(get != null)
            {
                push.Supplier = get;
                myContext.Item.Add(push);
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
            else
            {
                return status;
            }
        }

        public bool Update(int id, ItemVM itemVM)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Update(id, itemVM);
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
