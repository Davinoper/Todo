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
    public class ResidencialController : ApiController
    {
        private TodoFriensContext db = new TodoFriensContext();

        // GET: api/Residencial
        public IQueryable<Residencial> GetTarefas()
        {
            foreach (var item in db.Residenciais)
            {
                item.Horario = db.Horarios.Find(HorarioDao.findIdByTarefa(item));
                item.Usuario = db.Usuarios.Find(UsuarioDao.findIdByTarefa(item));



            }
            return db.Residenciais;
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        // GET: api/Residencial/5
        [ResponseType(typeof(Residencial))]
        public IHttpActionResult GetResidencial(int id)
        {

            Residencial residencial = db.Residenciais.Find(id);
            if (residencial == null)
            {
                return NotFound();
            }

            return Ok(residencial);
        }

        // PUT: api/Residencial/5
        [ResponseType(typeof(Residencial))]
        public IHttpActionResult PutResidencial(int id, Residencial residencial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != residencial.Id)
            {
                return BadRequest();
            }


            residencial.Horario = db.Horarios.Find(residencial.Horario.Id);
            residencial.Usuario = db.Usuarios.Find(residencial.Usuario.Id);

            ResidencialDao.putAux(residencial);

            db.Entry(residencial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidencialExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Residencial residencialSaved =  db.Residenciais.Find(residencial.Id);

            return Ok(residencialSaved);
        }

        // POST: api/Residencial
        [ResponseType(typeof(Residencial))]
        public IHttpActionResult PostResidencial(Residencial residencial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = db.Usuarios.Find(residencial.Usuario.Id);
            Horario horario = db.Horarios.Find(residencial.Horario.Id);
            residencial.Horario = horario;
            residencial.Usuario = usuario;

            db.Tarefas.Add(residencial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = residencial.Id }, residencial);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        // DELETE: api/Residencial/5
        [ResponseType(typeof(Residencial))]
        public IHttpActionResult DeleteResidencial(int id)
        {
            Residencial residencial = db.Residenciais.Find(id);
            if (residencial == null)
            {
                return NotFound();
            }

            db.Tarefas.Remove(residencial);
            db.SaveChanges();

            return Ok(residencial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResidencialExists(int id)
        {
            return db.Tarefas.Count(e => e.Id == id) > 0;
        }
    }
}