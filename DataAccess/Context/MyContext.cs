using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyContext")
        {

        }

        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}
