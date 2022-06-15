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
using TodoFriends.Data;
using TodoFriends.Models;

namespace TodoFriends.Controllers
{
    public class ComodoesController : ApiController
    {
        private TodoFriensContext db = new TodoFriensContext();

        // GET: api/Comodoes
        public IQueryable<Comodo> Getcomodos()
        {
            return db.comodos;
        }

        // GET: api/Comodoes/5
        [ResponseType(typeof(Comodo))]
        public IHttpActionResult GetComodo(int id)
        {
            Comodo comodo = db.comodos.Find(id);
            if (comodo == null)
            {
                return NotFound();
            }

            return Ok(comodo);
        }

        // PUT: api/Comodoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComodo(int id, Comodo comodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comodo.Id)
            {
                return BadRequest();
            }

            db.Entry(comodo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComodoExists(id))
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

        // POST: api/Comodoes
        [ResponseType(typeof(Comodo))]
        public IHttpActionResult PostComodo(Comodo comodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.comodos.Add(comodo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comodo.Id }, comodo);
        }

        // DELETE: api/Comodoes/5
        [ResponseType(typeof(Comodo))]
        public IHttpActionResult DeleteComodo(int id)
        {
            Comodo comodo = db.comodos.Find(id);
            if (comodo == null)
            {
                return NotFound();
            }

            db.comodos.Remove(comodo);
            db.SaveChanges();

            return Ok(comodo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComodoExists(int id)
        {
            return db.comodos.Count(e => e.Id == id) > 0;
        }
    }
}