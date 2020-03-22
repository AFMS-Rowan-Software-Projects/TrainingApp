using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp.Models
{
    public class ClassDate
    {
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClassGUID { get; set; }
        
        // Foriegn Key to Course
        [Required(ErrorMessage = "CourseId is required")]
        public int CourseId { get; set; }
        // Navigation property
        public Course Course { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }
        
        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }
        
        [Required(ErrorMessage = "Start Time is required")]
        public DateTime StartTime { get; set; }
        
        [Required(ErrorMessage = "End Time is required")]
        public DateTime EndTime { get; set; }

        // Foriegn Key to Location
        [Required(ErrorMessage = "LocationId is required")]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        [Required(ErrorMessage = "Number of Slots is required")]
        public int Slots { get; set; }

        // Foriegn Key to Trainer
        [Required(ErrorMessage = "TrainerId is required")]
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        [Required(ErrorMessage = "Active Status is required")]
        public Boolean Active { get; set; }

    }
}