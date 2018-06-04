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
using DesACID_ApiWeb.Models;

namespace DesACID_ApiWeb.Controllers
{
    public class PaisesController : ApiController
    {
        private Model db = new Model();

        // GET: api/Paises
        public IQueryable<Paises> GetPaises()
        {
            return db.Paises;
        }

        // GET: api/Paises/5
        [ResponseType(typeof(Paises))]
        public async Task<IHttpActionResult> GetPaises(string id)
        {
            Paises paises = await db.Paises.FindAsync(id);
            if (paises == null)
            {
                return NotFound();
            }

            return Ok(paises);
        }

        // PUT: api/Paises/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPaises(string id, Paises paises)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paises.Country_Code)
            {
                return BadRequest();
            }

            db.Entry(paises).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisesExists(id))
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

        // POST: api/Paises
        [ResponseType(typeof(Paises))]
        public async Task<IHttpActionResult> PostPaises(Paises paises)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Paises.Add(paises);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaisesExists(paises.Country_Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = paises.Country_Code }, paises);
        }

        // DELETE: api/Paises/5
        [ResponseType(typeof(Paises))]
        public async Task<IHttpActionResult> DeletePaises(string id)
        {
            Paises paises = await db.Paises.FindAsync(id);
            if (paises == null)
            {
                return NotFound();
            }

            db.Paises.Remove(paises);
            await db.SaveChangesAsync();

            return Ok(paises);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaisesExists(string id)
        {
            return db.Paises.Count(e => e.Country_Code == id) > 0;
        }
    }
}