using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using ProductsManagementSystemWithMVC.CustomValidations;

namespace Company.DomainModels
{
   // [UserHobbiesAttributes(ErrorMessage = "At least one hobby and maximum of four hobbies should be selected")]
    public class User
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }   
        public int Mobile { get; set; }
        
        public bool Photography { get; set; }
     
        public bool Gardening { get; set; }
      
        public bool Dance { get; set; }
       
        public bool Hiking { get; set; }
       
        public bool Painting { get; set; }

        /*public List<string> HobbiesNames { get; set; } = new List<string>() { "Photography", "Gardening", "Dance", "Hiking", "Painting" };*/

    }
}