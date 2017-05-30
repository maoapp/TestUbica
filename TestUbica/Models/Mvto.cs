using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestUbica.Models
{
    public class Mvto
    {
        [Key]
        public int MvtoId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date{get;set;}

        [Column("Nit")]
        public int ThirdId { get; set; }

        public virtual Third Third { get; set; }

        public ICollection<MvtoDetail> MvtoDetail { get; set; }
    }
}