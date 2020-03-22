using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name of Location is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Address is required")]
        public string Address1 { get; set; } 
        
        public string Address2 { get; set; }
        
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        
        [Required(ErrorMessage = "Zip Code is required")]
        public string Zipcode { get; set; }
        
        [Required(ErrorMessage = "Room Name is required")]
        public string Room { get; set; }
        
        [Required(ErrorMessage = "Max Room Capacity is required")]
        public int MaxCap { get; set; }
        
    }
}