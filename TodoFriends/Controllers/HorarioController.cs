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
    public class HorarioController : ApiController
    {
        private TodoFriensContext db = new TodoFriensContext();

        // GET: api/Horario
        public IQueryable<Horario> GetHorarios()
        {
            return db.Horarios;
        }

        // GET: api/Horario/5
        [ResponseType(typeof(Horario))]
        public IHttpActionResult GetHorario(int id)
        {
            Horario horario = db.Horarios.Find(id);
            if (horario == null)
            {
                return NotFound();
            }

            return Ok(horario);
        }

        // PUT: api/Horario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHorario(int id, Horario horario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != horario.Id)
            {
                return BadRequest();
            }

            db.Entry(horario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioExists(id))
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

        // POST: api/Horario
        [ResponseType(typeof(Horario))]
        public IHttpActionResult PostHorario(Horario horario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Horarios.Add(horario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = horario.Id }, horario);
        }

        // DELETE: api/Horario/5
        [ResponseType(typeof(Horario))]
        public IHttpActionResult DeleteHorario(int id)
        {
            Horario horario = db.Horarios.Find(id);
            if (horario == null)
            {
                return NotFound();
            }

            db.Horarios.Remove(horario);
            db.SaveChanges();

            return Ok(horario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HorarioExists(int id)
        {
            return db.Horarios.Count(e => e.Id == id) > 0;
        }
    }
}