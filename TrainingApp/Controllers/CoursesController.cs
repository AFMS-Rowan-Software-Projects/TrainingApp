using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TrainingApp.Data;
using TrainingApp.Models;

namespace TrainingApp.Controllers
{
    public class CoursesController : ApiController
    {
        private TrainingAppContext db = new TrainingAppContext();

        // GET: api/Courses
        public IQueryable<CourseDto> GetCourses()
        {
            var courses = from b in db.Courses
                          select new CourseDto()
                          {
                              Id = b.Id,
                              CourseGUID = b.CourseGUID,
                              CourseName = b.CourseName,
                              CatName = b.Category.CatName
                          };

            return courses;
        }

        // GET: api/Courses/5
        [ResponseType(typeof(CourseDetailDto))]
        public async Task<IHttpActionResult> GetCourse(int id)
        {
            var course = await db.Courses.Include(b => b.Category).Select(b =>
            new CourseDetailDto()
            {
                Id = b.Id,
                CourseGUID = b.CourseGUID,
                CourseName = b.CourseName,
                CourseDesc = b.CourseDesc,
                PreReqs = b.PreReqs,
                Tuition = b.Tuition,
                Fees = b.Fees,
                FeeDesc = b.FeeDesc,
                CatName = b.Category.CatName,
                Active = b.Active
            }).SingleOrDefaultAsync(b => b.Id == id);
        if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/Courses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCourse(int id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.Id)
            {
                return BadRequest();
            }

            db.Entry(course).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Courses
        [ResponseType(typeof(CourseDto))]
        public async Task<IHttpActionResult> PostCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(course);
            await db.SaveChangesAsync();

            db.Entry(course).Reference(x => x.Category).Load();

            var dto = new CourseDto()
            {
                Id = course.Id,
                CourseGUID = course.CourseGUID,
                CourseName = course.CourseName,
                CatName = course.Category.CatName
            };

            return CreatedAtRoute("DefaultApi", new { id = course.Id }, dto);
        }

        // DELETE: api/Courses/5
        [ResponseType(typeof(Course))]
        public async Task<IHttpActionResult> DeleteCourse(int id)
        {
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            db.Courses.Remove(course);
            await db.SaveChangesAsync();

            return Ok(course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseExists(int id)
        {
            return db.Courses.Count(e => e.Id == id) > 0;
        }
    }
}