using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestUbica.Models
{
    public class Third
    {
        [Key]
        [Column("Nit")]
        public int ThirdId { get; set; }

        public string Name { get; set; }

        public int quota { get; set; }

        public ICollection<Mvto> Mvto { get; set; }
    }
}