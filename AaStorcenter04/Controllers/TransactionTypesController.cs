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
    public class TransactionTypesController : ApiController
    {
        private mmdi0916_1062026Entities db = new mmdi0916_1062026Entities();

        // GET: api/TransactionTypes
        public IQueryable<TransactionType> GetTransactionTypes()
        {
            return db.TransactionTypes;
        }

        // GET: api/TransactionTypes/5
        [ResponseType(typeof(TransactionType))]
        public IHttpActionResult GetTransactionType(int id)
        {
            TransactionType transactionType = db.TransactionTypes.Find(id);
            if (transactionType == null)
            {
                return NotFound();
            }

            return Ok(transactionType);
        }

        // PUT: api/TransactionTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransactionType(int id, TransactionType transactionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transactionType.TransTypeID)
            {
                return BadRequest();
            }

            db.Entry(transactionType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionTypeExists(id))
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

        // POST: api/TransactionTypes
        [ResponseType(typeof(TransactionType))]
        public IHttpActionResult PostTransactionType(TransactionType transactionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TransactionTypes.Add(transactionType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TransactionTypeExists(transactionType.TransTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = transactionType.TransTypeID }, transactionType);
        }

        // DELETE: api/TransactionTypes/5
        [ResponseType(typeof(TransactionType))]
        public IHttpActionResult DeleteTransactionType(int id)
        {
            TransactionType transactionType = db.TransactionTypes.Find(id);
            if (transactionType == null)
            {
                return NotFound();
            }

            db.TransactionTypes.Remove(transactionType);
            db.SaveChanges();

            return Ok(transactionType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionTypeExists(int id)
        {
            return db.TransactionTypes.Count(e => e.TransTypeID == id) > 0;
        }
    }
}