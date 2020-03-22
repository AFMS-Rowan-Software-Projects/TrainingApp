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
    public class AttendedsController : ApiController
    {
        private TrainingAppContext db = new TrainingAppContext();

        // GET: api/Attendeds
        public IQueryable<Attended> GetAttendeds()
        {
            return db.Attendeds
                .Include(b => b.ClassDate)
                .Include(b => b.Student);
        }

        // GET: api/Attendeds/5
        [ResponseType(typeof(Attended))]
        public async Task<IHttpActionResult> GetAttended(int id)
        {
            Attended attended = await db.Attendeds.FindAsync(id);
            if (attended == null)
            {
                return NotFound();
            }

            return Ok(attended);
        }

        // PUT: api/Attendeds/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAttended(int id, Attended attended)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attended.Id)
            {
                return BadRequest();
            }

            db.Entry(attended).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendedExists(id))
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

        // POST: api/Attendeds
        [ResponseType(typeof(Attended))]
        public async Task<IHttpActionResult> PostAttended(Attended attended)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Attendeds.Add(attended);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = attended.Id }, attended);
        }

        // DELETE: api/Attendeds/5
        [ResponseType(typeof(Attended))]
        public async Task<IHttpActionResult> DeleteAttended(int id)
        {
            Attended attended = await db.Attendeds.FindAsync(id);
            if (attended == null)
            {
                return NotFound();
            }

            db.Attendeds.Remove(attended);
            await db.SaveChangesAsync();

            return Ok(attended);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttendedExists(int id)
        {
            return db.Attendeds.Count(e => e.Id == id) > 0;
        }
    }
}