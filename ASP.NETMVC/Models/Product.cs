using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NETMVC.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Enter Name")]
        public string ProductName { get; set; }
        //Foreign key
       
        public int CategoryId { get; set; }
        //navigation property
        public virtual Category Category { get; set; }
    }
}