﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProductsManagementSystemWithMVC.CustomValidations;


namespace ProductsManagementSystemWithMVC.Models
{
    [Table("Products", Schema ="dbo")]
    public class Product
    {
        [Key]
        [Display(Name ="Product ID")]
        public long ProductID { get; set; }


        [Display(Name ="Product Name")]
        [Required(ErrorMessage ="Product Name cannot be blank")]
        [RegularExpression(@"^[A-Za-z ]*$",ErrorMessage ="Alphabet only")]
        [MaxLength(50,ErrorMessage ="product name can be maximum of 50 characters")]
        [MinLength(2,ErrorMessage ="Product name must by 2 charachters or longer")]
        public string ProductName { get; set; }


        [Display(Name ="Price")]
        [Required(ErrorMessage ="Price cannot be blank")]
        [Range(0,1000000,ErrorMessage ="Price must be positive and under 1,000,000")]
        [DivisibleBy10(ErrorMessage = "price should be in mulitples of 10")]
        public Nullable<decimal> Price { get; set; }


        [Display(Name ="Date of Purchase")]
        [Column("DateOfPurchase", TypeName ="datetime")]
        public Nullable<System.DateTime> DOP { get; set; }


        [Display(Name ="Availablity Status")]
        [Required]
        public string AvailabilityStatus { get; set; }


        [Display(Name ="Category ID")]
        [Required(ErrorMessage ="You must choose a category")]
        public Nullable<long> CategoryID { get; set; }
        
        [Display(Name = "Brand ID")]
        [Required(ErrorMessage ="You must choose a brand")]
        public Nullable<long> BrandID { get; set; }

        [Display(Name ="Active")]
        public Nullable<bool> Active { get; set; }
        public string Photo { get; set; }


        public Nullable<decimal> Quntity { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}