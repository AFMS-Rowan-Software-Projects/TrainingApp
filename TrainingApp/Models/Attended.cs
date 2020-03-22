using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Models
{
    public class Attended
    {
        [Key]
        public int Id { get; set; }

        // Foriegn Key to ClassDate
        [Required(ErrorMessage = " is required")]
        public int ClassDateId { get; set; }
        public ClassDate ClassDate { get; set; }

        // Foriegn Key to Student
        [Required(ErrorMessage = "StudentId is required")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required(ErrorMessage = "Payment Type is required")]
        public string PaymentType { get; set; }
        
        [Required(ErrorMessage = "Approved Value is required")]
        public int Approved { get; set; }
        
        [Required(ErrorMessage = "Transaction Id is required")]
        public string TransID { get; set; }
        
        public float Grade { get; set; }
    }
}