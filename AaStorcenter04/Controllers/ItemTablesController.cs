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
    public class ItemTablesController : ApiController
    {
        private mmdi0916_1062026Entities db = new mmdi0916_1062026Entities();

        // GET: api/ItemTables
        public IQueryable<ItemTable> GetItemTables()
        {
            return db.ItemTables;
        }

        // GET: api/ItemTables/5
        [ResponseType(typeof(ItemTable))]
        public IHttpActionResult GetItemTable(int id)
        {
            ItemTable itemTable = db.ItemTables.Find(id);
            if (itemTable == null)
            {
                return NotFound();
            }

            return Ok(itemTable);
        }

        // PUT: api/ItemTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItemTable(int id, ItemTable itemTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemTable.ItemID)
            {
                return BadRequest();
            }

            db.Entry(itemTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTableExists(id))
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

        // POST: api/ItemTables
        [ResponseType(typeof(ItemTable))]
        public IHttpActionResult PostItemTable(ItemTable itemTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemTables.Add(itemTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ItemTableExists(itemTable.ItemID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = itemTable.ItemID }, itemTable);
        }

        // DELETE: api/ItemTables/5
        [ResponseType(typeof(ItemTable))]
        public IHttpActionResult DeleteItemTable(int id)
        {
            ItemTable itemTable = db.ItemTables.Find(id);
            if (itemTable == null)
            {
                return NotFound();
            }

            db.ItemTables.Remove(itemTable);
            db.SaveChanges();

            return Ok(itemTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemTableExists(int id)
        {
            return db.ItemTables.Count(e => e.ItemID == id) > 0;
        }
    }
}