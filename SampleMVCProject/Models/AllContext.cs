using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleMVCProject.Models
{
    public class AllContext : DbContext
    {
        public AllContext() : base("Con")
        {

        }

        public DbSet<Fruit> fruits { get; set; }
        public DbSet<Vegetable> vegetables { get; set; }
        public DbSet<Season> seasons { get; set; }
        public DbSet<FruitSupplier> fruitSuppliers { get; set; }

        public System.Data.Entity.DbSet<SampleMVCProject.Models.Membership> Memberships { get; set; }
        public object User { get; internal set; }
    }
}