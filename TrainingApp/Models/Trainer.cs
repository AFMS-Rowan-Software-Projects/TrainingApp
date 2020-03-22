using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Models
{
    public class Trainer
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } 
        
        public string MiddleInitial { get; set; } 
        
        public string Credentials { get; set; }
        
        [Required(ErrorMessage = "Address is required")]
        public string Address1 { get; set; } 
        
        public string Address2 { get; set; } 
        
        public string City { get; set; }
        
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        
        [Required(ErrorMessage = "Zip Code is required")]
        public string Zipcode { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Active is required")]
        public Boolean Active { get; set; } = false;
}
}