using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AaStorcenterDataA;

namespace AaStorcenter04.Controllers
{
    public class CharitiesController : ApiController
    {
        private mmdi0916_1062026Entities db = new mmdi0916_1062026Entities();

        // GET: api/Charities
        public IQueryable<Charity> GetCharities()
        {
            return db.Charities;
        }

        // GET: api/Charities/5
        [ResponseType(typeof(Charity))]
        public IHttpActionResult GetCharity(int id)
        {
            Charity charity = db.Charities.Find(id);
            if (charity == null)
            {
                return NotFound();
            }

            return Ok(charity);
        }

        // PUT: api/Charities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCharity(int id, Charity charity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != charity.CharityID)
            {
                return BadRequest();
            }

            db.Entry(charity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharityExists(id))
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

        // POST: api/Charities
        [ResponseType(typeof(Charity))]
        public IHttpActionResult PostCharity(Charity charity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Charities.Add(charity);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CharityExists(charity.CharityID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = charity.CharityID }, charity);
        }

        // DELETE: api/Charities/5
        [ResponseType(typeof(Charity))]
        public IHttpActionResult DeleteCharity(int id)
        {
            Charity charity = db.Charities.Find(id);
            if (charity == null)
            {
                return NotFound();
            }

            db.Charities.Remove(charity);
            db.SaveChanges();

            return Ok(charity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharityExists(int id)
        {
            return db.Charities.Count(e => e.CharityID == id) > 0;
        }
    }
}