using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudentGUID { get; set; }
        
        [Required(ErrorMessage = "First Name is required")]
        public int FirstNsme { get; set; }
        
        [Required(ErrorMessage = "Last Name is required")]
        public int LastName { get; set; } 
        
        public int MiddleInitial { get; set; }
        
        [Required(ErrorMessage = "Address is required")]
        public int Address1 { get; set; } 
        
        public int Address2 { get; set; }
        
        [Required(ErrorMessage = "City is required")]
        public int City { get; set; }
        
        [Required(ErrorMessage = "State is required")]
        public int State { get; set; }
        
        [Required(ErrorMessage = "Zip Code is required")]
        public int Zipcode { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        public int Email { get; set; }
        
        [Required(ErrorMessage = "Phone Number is required")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "Active Status is required")]
        public Boolean Active { get; set; } = false;

        [Required(ErrorMessage = "Verified is required")]
        public Boolean Verified { get; set; } = false;
        
        [Required(ErrorMessage = "Username is required")]
        public int Username { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public int Password { get; set; }

        [Required]
        public DateTime Create_time { get; } = DateTime.UtcNow;
    }
}