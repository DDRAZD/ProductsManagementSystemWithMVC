using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProductsManagementSystemWithMVC.Models
{
    [Table("Products", Schema ="dbo")]
    public class Product
    {
        [Key]
        [Display(Name ="Product ID")]
        public long ProductID { get; set; }


        [Display(Name ="Product Name")]
        [Required]
        public string ProductName { get; set; }


        [Display(Name ="Price")]
        [Required]
        public Nullable<decimal> Price { get; set; }


        [Display(Name ="Date of Purchase")]
        [Column("DateOfPurchase", TypeName ="datetime")]
        public Nullable<System.DateTime> DOP { get; set; }


        [Display(Name ="Availablity Status")]
        public string AvailabilityStatus { get; set; }


        [Display(Name ="Category ID")]
        [Required]
        public Nullable<long> CategoryID { get; set; }
        
        [Display(Name = "Brand ID")]
        [Required]
        public Nullable<long> BrandID { get; set; }

        [Display(Name ="Active")]
        public Nullable<bool> Active { get; set; }
        public string Photo { get; set; }


        public Nullable<decimal> Quntity { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}