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
    [Table("TB_M_Item")]
    public class Item : BaseModel
    {
        //constructor
        public Item()
        {

        }

        //constructor with parameter
        public Item(ItemVM itemVM)
        {
            this.Name = itemVM.Name;
            this.Stock = itemVM.Stock;
            this.Price = itemVM.Price;
            this.CreateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Update(int id, ItemVM itemVM)
        {
            this.Id = id;
            this.Name = itemVM.Name;
            this.Stock = itemVM.Stock;
            this.Price = itemVM.Price;
            this.Supplier_Id = itemVM.Supplier_Id;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        [ForeignKey("Suppliers")]
        public int Supplier_Id { get; set; } //manual foreignkey to Supplier table
        public Suppliers Suppliers { get; set; } //automatic foreignkey to Supplier table
    }

}
