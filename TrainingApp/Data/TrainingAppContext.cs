using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrainingApp.Data
{
    public class TrainingAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TrainingAppContext() : base("name=TrainingAppContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<TrainingApp.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<TrainingApp.Models.ClassDate> ClassDates { get; set; }

        public System.Data.Entity.DbSet<TrainingApp.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<TrainingApp.Models.Attended> Attendeds { get; set; }

        public System.Data.Entity.DbSet<TrainingApp.Models.Location> Locations { get; set; }

        public System.Data.Entity.DbSet<TrainingApp.Models.Trainer> Trainers { get; set; }

        public System.Data.Entity.DbSet<TrainingApp.Models.Category> Categories { get; set; }
    }
}
