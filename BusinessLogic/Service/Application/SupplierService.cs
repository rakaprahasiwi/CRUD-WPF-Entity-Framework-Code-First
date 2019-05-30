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
    //this service for validation
    public class SupplierService : ISupplierService
    {
        ISupplierRepository isupplierRepository = new SupplierRepository();
        bool status = false;

        public bool Delete(int id)
        {
            return isupplierRepository.Delete(id);
        }

        public List<Suppliers> Get()
        {
            return isupplierRepository.Get();
        }

        public Suppliers Get(int id)
        {
            return isupplierRepository.Get(id);
        }

        public List<Suppliers> GetSearch(string values)
        {
            return isupplierRepository.GetSearch(values);           
        }

        public bool Insert(SupplierVM supplierVM)
        {
            if (string.IsNullOrWhiteSpace(supplierVM.Name))
            {
                return status;
            }
            else
            {
                return isupplierRepository.Insert(supplierVM);
            }
        }

        public bool Update(int id, SupplierVM supplierVM)
        {
            if (string.IsNullOrWhiteSpace(supplierVM.Name))
            {
                return status;
            }
            else
            {
                return isupplierRepository.Update(id, supplierVM);
            }            
        }
    }
}
