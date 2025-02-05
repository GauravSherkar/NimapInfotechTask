using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NETMVC.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId {  get; set; }
        [Required(ErrorMessage = "Enter Name")]

        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get;set; }
    }
}