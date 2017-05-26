using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUbica.Models
{
    public class Product
    {
        [Key]        
        public int ProductId { get; set; }

        public string Description { get; set; }

        public double value { get; set; }

        public ICollection<MvtoDetail> MvtoDetails { get; set; }
    }
}