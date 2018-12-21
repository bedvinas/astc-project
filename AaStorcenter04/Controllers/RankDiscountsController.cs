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
    public class RankDiscountsController : ApiController
    {
        private mmdi0916_1062026Entities db = new mmdi0916_1062026Entities();

        // GET: api/RankDiscounts
        public IQueryable<RankDiscount> GetRankDiscounts()
        {
            return db.RankDiscounts;
        }

        // GET: api/RankDiscounts/5
        [ResponseType(typeof(RankDiscount))]
        public IHttpActionResult GetRankDiscount(int id)
        {
            RankDiscount rankDiscount = db.RankDiscounts.Find(id);
            if (rankDiscount == null)
            {
                return NotFound();
            }

            return Ok(rankDiscount);
        }

        // PUT: api/RankDiscounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRankDiscount(int id, RankDiscount rankDiscount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rankDiscount.RDID)
            {
                return BadRequest();
            }

            db.Entry(rankDiscount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RankDiscountExists(id))
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

        // POST: api/RankDiscounts
        [ResponseType(typeof(RankDiscount))]
        public IHttpActionResult PostRankDiscount(RankDiscount rankDiscount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RankDiscounts.Add(rankDiscount);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RankDiscountExists(rankDiscount.RDID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rankDiscount.RDID }, rankDiscount);
        }

        // DELETE: api/RankDiscounts/5
        [ResponseType(typeof(RankDiscount))]
        public IHttpActionResult DeleteRankDiscount(int id)
        {
            RankDiscount rankDiscount = db.RankDiscounts.Find(id);
            if (rankDiscount == null)
            {
                return NotFound();
            }

            db.RankDiscounts.Remove(rankDiscount);
            db.SaveChanges();

            return Ok(rankDiscount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RankDiscountExists(int id)
        {
            return db.RankDiscounts.Count(e => e.RDID == id) > 0;
        }
    }
}