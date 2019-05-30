using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public interface ISupplierRepository
    {
        List<Suppliers> Get();
        List<Suppliers> GetSearch(string values);
        Suppliers Get(int id);
        bool Insert(SupplierVM supplierVM);
        bool Update(int id, SupplierVM supplierVM);
        bool Delete(int id);
    }
}
