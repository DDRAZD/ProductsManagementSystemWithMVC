using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Company.DomainModels
{
    public class Brand
    {
        [Key]
        [Display(Name ="Brand")]
        public long BrandID { get; set; }
        [Display(Name ="Brand Name")]
        public string BrandName { get; set; }
    }
}
