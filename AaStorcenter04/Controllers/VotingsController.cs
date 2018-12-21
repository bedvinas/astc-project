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
    public class VotingsController : ApiController
    {
        private mmdi0916_1062026Entities db = new mmdi0916_1062026Entities();

        // GET: api/Votings
        public IQueryable<Voting> GetVotings()
        {
            return db.Votings;
        }

        // GET: api/Votings/5
        [ResponseType(typeof(Voting))]
        public IHttpActionResult GetVoting(int id)
        {
            Voting voting = db.Votings.Find(id);
            if (voting == null)
            {
                return NotFound();
            }

            return Ok(voting);
        }

        // PUT: api/Votings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVoting(int id, Voting voting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voting.VoteID)
            {
                return BadRequest();
            }

            db.Entry(voting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VotingExists(id))
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

        // POST: api/Votings
        [ResponseType(typeof(Voting))]
        public IHttpActionResult PostVoting(Voting voting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Votings.Add(voting);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VotingExists(voting.VoteID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = voting.VoteID }, voting);
        }

        // DELETE: api/Votings/5
        [ResponseType(typeof(Voting))]
        public IHttpActionResult DeleteVoting(int id)
        {
            Voting voting = db.Votings.Find(id);
            if (voting == null)
            {
                return NotFound();
            }

            db.Votings.Remove(voting);
            db.SaveChanges();

            return Ok(voting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VotingExists(int id)
        {
            return db.Votings.Count(e => e.VoteID == id) > 0;
        }
    }
}