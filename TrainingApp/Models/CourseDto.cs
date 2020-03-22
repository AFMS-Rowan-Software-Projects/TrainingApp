using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingApp.Models
{
    public class CourseDto
    {
        public int Id { get; set; }
        public Guid CourseGUID { get; set; }
        public string CourseName { get; set; }
        public string CatName { get; set; }

    }
}