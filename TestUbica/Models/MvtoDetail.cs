using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUbica.Models
{
    public class MvtoDetail
    {
        [Key]
        public int MvtoDetailId { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }

        public int ProductId{get;set;}

        public int MvtoId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Mvto Mvto { get; set; }

        
    }
}