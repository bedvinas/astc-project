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
    public class AccRolesController : ApiController
    {
        private mmdi0916_1062026Entities db = new mmdi0916_1062026Entities();

        // GET: api/AccRoles
        public IQueryable<AccRole> GetAccRoles()
        {
            return db.AccRoles;
        }

        // GET: api/AccRoles/5
        [ResponseType(typeof(AccRole))]
        public IHttpActionResult GetAccRole(int id)
        {
            AccRole accRole = db.AccRoles.Find(id);
            if (accRole == null)
            {
                return NotFound();
            }

            return Ok(accRole);
        }

        // PUT: api/AccRoles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccRole(int id, AccRole accRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accRole.AccRoleID)
            {
                return BadRequest();
            }

            db.Entry(accRole).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccRoleExists(id))
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

        // POST: api/AccRoles
        [ResponseType(typeof(AccRole))]
        public IHttpActionResult PostAccRole(AccRole accRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccRoles.Add(accRole);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccRoleExists(accRole.AccRoleID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accRole.AccRoleID }, accRole);
        }

        // DELETE: api/AccRoles/5
        [ResponseType(typeof(AccRole))]
        public IHttpActionResult DeleteAccRole(int id)
        {
            AccRole accRole = db.AccRoles.Find(id);
            if (accRole == null)
            {
                return NotFound();
            }

            db.AccRoles.Remove(accRole);
            db.SaveChanges();

            return Ok(accRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccRoleExists(int id)
        {
            return db.AccRoles.Count(e => e.AccRoleID == id) > 0;
        }
    }
}