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
    public class TransactionTablesController : ApiController
    {
        private mmdi0916_1062026Entities db = new mmdi0916_1062026Entities();

        // GET: api/TransactionTables
        public IQueryable<TransactionTable> GetTransactionTables()
        {
            return db.TransactionTables;
        }

        // GET: api/TransactionTables/5
        [ResponseType(typeof(TransactionTable))]
        public IHttpActionResult GetTransactionTable(int id)
        {
            TransactionTable transactionTable = db.TransactionTables.Find(id);
            if (transactionTable == null)
            {
                return NotFound();
            }

            return Ok(transactionTable);
        }

        // PUT: api/TransactionTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransactionTable(int id, TransactionTable transactionTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transactionTable.TransactionID)
            {
                return BadRequest();
            }

            db.Entry(transactionTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionTableExists(id))
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

        // POST: api/TransactionTables
        [ResponseType(typeof(TransactionTable))]
        public IHttpActionResult PostTransactionTable(TransactionTable transactionTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TransactionTables.Add(transactionTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TransactionTableExists(transactionTable.TransactionID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = transactionTable.TransactionID }, transactionTable);
        }

        // DELETE: api/TransactionTables/5
        [ResponseType(typeof(TransactionTable))]
        public IHttpActionResult DeleteTransactionTable(int id)
        {
            TransactionTable transactionTable = db.TransactionTables.Find(id);
            if (transactionTable == null)
            {
                return NotFound();
            }

            db.TransactionTables.Remove(transactionTable);
            db.SaveChanges();

            return Ok(transactionTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionTableExists(int id)
        {
            return db.TransactionTables.Count(e => e.TransactionID == id) > 0;
        }
    }
}