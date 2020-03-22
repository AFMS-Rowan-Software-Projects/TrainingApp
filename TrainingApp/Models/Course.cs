using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CourseGUID { get; set; }
        
        [Required(ErrorMessage = "Course Name is required")] 
        public string CourseName { get; set; }
        
        public string CourseDesc { get; set; }
        
        public string PreReqs { get; set; }
        
        [Required(ErrorMessage = "Tuition Amount is required")] 
        public decimal Tuition { get; set; }
        
        public decimal Fees { get; set; }
        
        public string FeeDesc { get; set; }
        
        // Foreign Key
        [Required(ErrorMessage = "CategoryId is required")] 
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Active Status is required")] 
        public Boolean Active { get; set; }

    }
}
