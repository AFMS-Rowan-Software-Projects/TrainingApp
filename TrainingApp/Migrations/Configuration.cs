namespace TrainingApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TrainingApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TrainingApp.Data.TrainingAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TrainingApp.Data.TrainingAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Categories.AddOrUpdate(x => x.Id,
                new Category() { Id = 1, CatName = "Docker" },
                new Category() { Id = 2, CatName = "Programming" }
                        );

            context.Locations.AddOrUpdate(x => x.Id,
                new Location() { Id = 1, Name = "Training Center Building", Address1 = "123 Any Street", City = "Anytown", State = "NJ", Zipcode = "08000", Room = "101", MaxCap = 35 },
                new Location() { Id = 2, Name = "Training Center Building", Address1 = "123 Any Street", City = "Anytown", State = "NJ", Zipcode = "08000", Room = "201", MaxCap = 35 }
            );

            context.Trainers.AddOrUpdate(x => x.Id,
                new Trainer() { Id = 1, FirstName = "Jane", LastName = "Doe", Address1 = "321 Foo Street", City = "Footown", State = "PA", Zipcode = "19001", Credentials = "CIS, PhD", Email = "trainer1@abctraining.com", Phone = "123-345-4567", Active = true },
                new Trainer() { Id = 2, FirstName = "Parch", LastName = "Ment", Address1 = "1245 Fooboo Street", City = "Footown", State = "PA", Zipcode = "19001", Credentials = "CIS", Email = "trainer2@abctraining.com", Phone = "321-543-7654", Active = true }

                    );

            context.Courses.AddOrUpdate(x => x.Id,
                new Course() 
                { 
                    Id = 1, 
                    CourseGUID = Guid.NewGuid(), 
                    CourseName = "Intro To Docker", 
                    CourseDesc = "This course will introduce the user to the Docker environment and the use of containers. Building and deploying new applications is faster with containers. Docker containers wrap up software and its dependencies into a standardized unit for software development that includes everything it needs to run: code, runtime, system tools and libraries.", 
                    Tuition = 200.00M, 
                    Fees = 25.00M, 
                    FeeDesc = "Lab Fees", 
                    PreReqs = "", 
                    CategoryId = 1, 
                    Active = false 
                },
                new Course() 
                { 
                    Id = 2, 
                    CourseGUID = Guid.NewGuid(), 
                    CourseName = "Advanced Docker", 
                    CourseDesc = "This is a course that gives the Docker user an Advanced Exposure to the indepth tools and features that makes Docker the development and delivery service of choice.", 
                    Tuition = 200.00M, 
                    Fees = 25.00M, 
                    FeeDesc = "Lab Fees", 
                    PreReqs = "", 
                    CategoryId = 1, 
                    Active = false 
                },
                new Course() 
                { 
                    Id = 3, 
                    CourseGUID = Guid.NewGuid(), 
                    CourseName = "Programming in Java: Part 1", 
                    CourseDesc = "Introduction to Java Programming", 
                    Tuition = 200.00M, 
                    Fees = 25.00M, 
                    FeeDesc = "Lab Fees", 
                    PreReqs = "", 
                    CategoryId = 2, 
                    Active = false 
                }
                );

            context.ClassDates.AddOrUpdate(x => x.Id,
                new ClassDate()
                {
                    Id = 1, 
                    ClassGUID = Guid.NewGuid(), 
                    CourseId = 1, 
                    StartDate = new DateTime(2020, 6, 10, 9, 0, 0), 
                    EndDate = new DateTime(2020, 6, 10, 12, 0, 0),
                    StartTime = new DateTime(2020, 6, 10, 9, 0, 0), 
                    EndTime = new DateTime(2020, 6, 10, 12, 0, 0), 
                    LocationId = 1, 
                    Slots = 25, 
                    TrainerId = 1, 
                    Active = false
                },
                new ClassDate()
                {
                    Id = 2,
                    ClassGUID = Guid.NewGuid(),
                    CourseId = 2,
                    StartDate = new DateTime(2020, 6, 10, 13, 0, 0),
                    EndDate = new DateTime(2020, 6, 10, 17, 0, 0),
                    StartTime = new DateTime(2020, 6, 10, 13, 0, 0),
                    EndTime = new DateTime(2020, 6, 10, 17, 0, 0),
                    LocationId = 1,
                    Slots = 25,
                    TrainerId = 1,
                    Active = false
                },
                new ClassDate()
                {
                    Id = 3,
                    ClassGUID = Guid.NewGuid(),
                    CourseId = 2,
                    StartDate = new DateTime(2020, 6, 11, 9, 0, 0),
                    EndDate = new DateTime(2020, 6, 11, 12, 0, 0),
                    StartTime = new DateTime(2020, 6, 11, 9, 0, 0),
                    EndTime = new DateTime(2020, 6, 11, 12, 0, 0),
                    LocationId = 1,
                    Slots = 25,
                    TrainerId = 2,
                    Active = false
                },
                new ClassDate()
                {
                    Id = 4,
                    ClassGUID = Guid.NewGuid(),
                    CourseId = 3,
                    StartDate = new DateTime(2020, 6, 11, 9, 0, 0),
                    EndDate = new DateTime(2020, 6, 11, 12, 0, 0),
                    StartTime = new DateTime(2020, 6, 11, 9, 0, 0),
                    EndTime = new DateTime(2020, 6, 11, 12, 0, 0),
                    LocationId = 2,
                    Slots = 25,
                    TrainerId = 2,
                    Active = false
                }
                );

            
        }
    }
}
