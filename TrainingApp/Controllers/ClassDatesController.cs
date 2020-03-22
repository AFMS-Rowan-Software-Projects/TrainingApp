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
    public class ClassDatesController : ApiController
    {
        private TrainingAppContext db = new TrainingAppContext();

        // GET: api/ClassDates
        public IQueryable<ClassDate> GetClassDates()
        {
            return db.ClassDates
                .Include(b => b.Course)
                .Include(b => b.Location)
                .Include(b => b.Trainer);
        }

        // GET: api/ClassDates/5
        [ResponseType(typeof(ClassDate))]
        public async Task<IHttpActionResult> GetClassDate(int id)
        {
            ClassDate classDate = await db.ClassDates.FindAsync(id);
            if (classDate == null)
            {
                return NotFound();
            }

            return Ok(classDate);
        }

        // PUT: api/ClassDates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClassDate(int id, ClassDate classDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classDate.Id)
            {
                return BadRequest();
            }

            db.Entry(classDate).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassDateExists(id))
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

        // POST: api/ClassDates
        [ResponseType(typeof(ClassDate))]
        public async Task<IHttpActionResult> PostClassDate(ClassDate classDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClassDates.Add(classDate);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = classDate.Id }, classDate);
        }

        // DELETE: api/ClassDates/5
        [ResponseType(typeof(ClassDate))]
        public async Task<IHttpActionResult> DeleteClassDate(int id)
        {
            ClassDate classDate = await db.ClassDates.FindAsync(id);
            if (classDate == null)
            {
                return NotFound();
            }

            db.ClassDates.Remove(classDate);
            await db.SaveChangesAsync();

            return Ok(classDate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassDateExists(int id)
        {
            return db.ClassDates.Count(e => e.Id == id) > 0;
        }
    }
}