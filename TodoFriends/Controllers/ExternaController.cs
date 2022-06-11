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
    public class ExternaController : ApiController
    {
        private TodoFriensContext db = new TodoFriensContext();

        // GET: api/Externa
        public IQueryable<Externa> GetTarefas()
        {
            foreach (var item in db.Externas)
            {
                item.Horario = db.Horarios.Find(HorarioDao.findIdByTarefa((Tarefa) item));
                item.Local = db.Locais.Find(LocalDao.findIdByTarefa(item));
                item.Usuario = db.Usuarios.Find(UsuarioDao.findIdByTarefa(item));

            }
            return db.Externas;
        }

        // GET: api/Externa/5
        [ResponseType(typeof(Externa))]
        public IHttpActionResult GetExterna(int id)
        {
            Externa externa = db.Externas.Find(id);
            if (externa == null)
            {
                return NotFound();
            }

            return Ok(externa);
        }

        // PUT: api/Externa/5
        [ResponseType(typeof(Externa))]
        public IHttpActionResult PutExterna(int id, Externa externa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != externa.Id)
            {
                return BadRequest();
            }

            externa.Local = db.Locais.Find(externa.Local.Id);
            externa.Usuario = db.Usuarios.Find(externa.Usuario.Id);
            externa.Horario = db.Horarios.Find(externa.Horario.Id);

            ExternaDao.putAux(externa);

            db.Entry(externa).State = EntityState.Modified;

            try
            {
                
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExternaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Externa externaSaved = db.Externas.Find(externa.Id);

            return Ok(externaSaved);
        }

        // POST: api/Externa
        [ResponseType(typeof(Externa))]
        public IHttpActionResult PostExterna(Externa externa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Local local = db.Locais.Find(externa.Local.Id);
            Horario horario = db.Horarios.Find(externa.Horario.Id);
            Usuario usuario = db.Usuarios.Find(externa.Usuario.Id);
            externa.Local = local;
            externa.Usuario = usuario;
            externa.Horario = horario;
            db.Externas.Add(externa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = externa.Id }, externa);
        }

        // DELETE: api/Externa/5
        [ResponseType(typeof(Externa))]
        public IHttpActionResult DeleteExterna(int id)
        {
            Externa externa = db.Externas.Find(id);
            if (externa == null)
            {
                return NotFound();
            }

            db.Externas.Remove(externa);
            db.SaveChanges();

            return Ok(externa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExternaExists(int id)
        {
            return db.Externas.Count(e => e.Id == id) > 0;
        }
    }
}