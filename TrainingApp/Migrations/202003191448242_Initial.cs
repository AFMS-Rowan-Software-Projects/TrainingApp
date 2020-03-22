namespace TrainingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassDateId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        PaymentType = c.String(nullable: false),
                        Approved = c.Int(nullable: false),
                        TransID = c.String(nullable: false),
                        Grade = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassDates", t => t.ClassDateId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.ClassDateId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.ClassDates",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ClassGUID = c.Guid(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        LocationId = c.Int(nullable: false),
                        Slots = c.Int(nullable: false),
                        TrainerId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.LocationId)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CourseGUID = c.Guid(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        CourseDesc = c.String(),
                        PreReqs = c.String(),
                        Tuition = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fees = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FeeDesc = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zipcode = c.String(nullable: false),
                        Room = c.String(nullable: false),
                        MaxCap = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MiddleInitial = c.String(),
                        Credentials = c.String(),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(nullable: false),
                        Zipcode = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StudentGUID = c.Guid(nullable: false, identity: true),
                        FirstNsme = c.Int(nullable: false),
                        LastName = c.Int(nullable: false),
                        MiddleInitial = c.Int(nullable: false),
                        Address1 = c.Int(nullable: false),
                        Address2 = c.Int(nullable: false),
                        City = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        Zipcode = c.Int(nullable: false),
                        Email = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Verified = c.Boolean(nullable: false),
                        Username = c.Int(nullable: false),
                        Password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendeds", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Attendeds", "ClassDateId", "dbo.ClassDates");
            DropForeignKey("dbo.ClassDates", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.ClassDates", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.ClassDates", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropIndex("dbo.ClassDates", new[] { "TrainerId" });
            DropIndex("dbo.ClassDates", new[] { "LocationId" });
            DropIndex("dbo.ClassDates", new[] { "CourseId" });
            DropIndex("dbo.Attendeds", new[] { "StudentId" });
            DropIndex("dbo.Attendeds", new[] { "ClassDateId" });
            DropTable("dbo.Students");
            DropTable("dbo.Trainers");
            DropTable("dbo.Locations");
            DropTable("dbo.Categories");
            DropTable("dbo.Courses");
            DropTable("dbo.ClassDates");
            DropTable("dbo.Attendeds");
        }
    }
}
