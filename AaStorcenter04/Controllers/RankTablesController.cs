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
    public class RankTablesController : ApiController
    {
        private mmdi0916_1062026Entities db = new mmdi0916_1062026Entities();

        // GET: api/RankTables
        public IQueryable<RankTable> GetRankTables()
        {
            return db.RankTables;
        }

        // GET: api/RankTables/5
        [ResponseType(typeof(RankTable))]
        public IHttpActionResult GetRankTable(int id)
        {
            RankTable rankTable = db.RankTables.Find(id);
            if (rankTable == null)
            {
                return NotFound();
            }

            return Ok(rankTable);
        }

        // PUT: api/RankTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRankTable(int id, RankTable rankTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rankTable.RankID)
            {
                return BadRequest();
            }

            db.Entry(rankTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RankTableExists(id))
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

        // POST: api/RankTables
        [ResponseType(typeof(RankTable))]
        public IHttpActionResult PostRankTable(RankTable rankTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RankTables.Add(rankTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RankTableExists(rankTable.RankID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rankTable.RankID }, rankTable);
        }

        // DELETE: api/RankTables/5
        [ResponseType(typeof(RankTable))]
        public IHttpActionResult DeleteRankTable(int id)
        {
            RankTable rankTable = db.RankTables.Find(id);
            if (rankTable == null)
            {
                return NotFound();
            }

            db.RankTables.Remove(rankTable);
            db.SaveChanges();

            return Ok(rankTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RankTableExists(int id)
        {
            return db.RankTables.Count(e => e.RankID == id) > 0;
        }
    }
}