using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingApp.Models
{
    public class CourseDetailDto
    {
        public int Id { get; set; }
        public Guid CourseGUID { get; set; }
        public string CourseName { get; set; }
        public string CourseDesc { get; set; }
        public string PreReqs { get; set; }
        public decimal Tuition { get; set; }
        public decimal Fees { get; set; }
        public string FeeDesc { get; set; }
        public string CatName { get; set; }
        public Boolean Active { get; set; }
    }
}