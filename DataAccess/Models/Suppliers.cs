using Core.Base;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("TB_M_Supplier")]
    public class Suppliers : BaseModel
    {
        //constructor
        public Suppliers()
        {

        }

        //constructor with parameter
        public Suppliers(SupplierVM supplierVM)
        {
            this.Name = supplierVM.Name;
            this.CreateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public string Name { get; set; }

        public void Update(int id, SupplierVM supplierVM)
        {
            this.Id = id;
            this.Name = supplierVM.Name;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
