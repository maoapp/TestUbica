using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestUbica.Models
{
    public class TestUbicaContext:DbContext
    {
        public TestUbicaContext():base("DefaultConnection"){
            
            }

        public System.Data.Entity.DbSet<TestUbica.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<TestUbica.Models.Third> Thirds { get; set; }

        public System.Data.Entity.DbSet<TestUbica.Models.Mvto> Mvtoes { get; set; }

        public System.Data.Entity.DbSet<TestUbica.Models.MvtoDetail> MvtoDetails { get; set; }
    }
}