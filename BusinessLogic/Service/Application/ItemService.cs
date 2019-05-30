using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.ViewModels;
using Common.Repository;
using Common.Repository.Application;

namespace BusinessLogic.Service.Application
{
    public class ItemService : IItemService
    {
        IItemRepository iitemrepository = new ItemRepository();

        bool status = false;
        public bool Delete(int id)
        {
            return iitemrepository.Delete(id);
        }

        public List<Item> Get()
        {
            return iitemrepository.Get();
        }

        public Item Get(int id)
        {
            return iitemrepository.Get(id);
        }

        public List<Item> GetSearch(string values)
        {
            return iitemrepository.GetSearch(values);
        }

        public bool Insert(ItemVM itemVM)
        {

            if (string.IsNullOrWhiteSpace(itemVM.Name) || string.IsNullOrWhiteSpace(itemVM.Stock.ToString()) || string.IsNullOrWhiteSpace(itemVM.Price.ToString()) || string.IsNullOrWhiteSpace(itemVM.Supplier_Id.ToString()))
            {
                return status;
            }
            else
            {
                return iitemrepository.Insert(itemVM);
            }
        }

        public bool Update(int id, ItemVM itemVM)
        {
            if (string.IsNullOrWhiteSpace(itemVM.Name))
            {
                return status;
            }
            else
            {
                return iitemrepository.Update(id, itemVM);
            }
        }
    }
}
