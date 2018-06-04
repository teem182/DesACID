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
    public class DatosController : ApiController
    {
        private Model db = new Model();

        // GET: api/Datos
        public IQueryable<Datos> GetDatos()
        {
            return db.Datos;
        }

        // GET: api/Datos/5
        [ResponseType(typeof(Datos))]
        public async Task<IHttpActionResult> GetDatos(int id)
        {
            Datos datos = await db.Datos.FindAsync(id);
            if (datos == null)
            {
                return NotFound();
            }

            return Ok(datos);
        }

        // PUT: api/Datos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDatos(int id, Datos datos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != datos.Datos_id)
            {
                return BadRequest();
            }

            db.Entry(datos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatosExists(id))
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

        // POST: api/Datos
        [ResponseType(typeof(Datos))]
        public async Task<IHttpActionResult> PostDatos(Datos datos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Datos.Add(datos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = datos.Datos_id }, datos);
        }

        // DELETE: api/Datos/5
        [ResponseType(typeof(Datos))]
        public async Task<IHttpActionResult> DeleteDatos(int id)
        {
            Datos datos = await db.Datos.FindAsync(id);
            if (datos == null)
            {
                return NotFound();
            }

            db.Datos.Remove(datos);
            await db.SaveChangesAsync();

            return Ok(datos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DatosExists(int id)
        {
            return db.Datos.Count(e => e.Datos_id == id) > 0;
        }
    }
}