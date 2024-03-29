﻿using System;
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
            AuxDao.deleteTrash();
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
            AuxDao.deleteTrash();
            Residencial residencial = db.Residenciais.Find(id);
            if (residencial == null)
            {
                return NotFound();
            }

            residencial.Horario = db.Horarios.Find(HorarioDao.findIdByTarefa(residencial));
            residencial.Usuario = db.Usuarios.Find(UsuarioDao.findIdByTarefa(residencial));
            
            foreach(var item in residencial.Comodos)
            {
                item.Residenciais = null;
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

            List<Comodo> comodoAux = new List<Comodo>();
            residencial.Horario = db.Horarios.Find(residencial.Horario.Id);
            residencial.Usuario = db.Usuarios.Find(residencial.Usuario.Id);

            foreach (var item in residencial.Comodos)
            {
                comodoAux.Add(db.comodos.Find((int)item.Id));
            }



            foreach (var item in comodoAux)
            {
                residencial.Comodos.Add((Comodo)item);
            }



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
            AuxDao.deleteTrash();
            return Ok();
        }

        // POST: api/Residencial
        [ResponseType(typeof(Residencial))]
        public IHttpActionResult PostResidencial(Residencial residencial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Comodo> comodoAux = new List<Comodo>(); 
            residencial.Horario = db.Horarios.Find(residencial.Horario.Id);
            residencial.Usuario = db.Usuarios.Find(residencial.Usuario.Id); ;
           

            foreach(var item in residencial.Comodos)
            {
                comodoAux.Add(db.comodos.Find((int) item.Id));
            }

          

            foreach(var item in comodoAux)
            {
                residencial.Comodos.Add((Comodo) item);
            }

            

            db.Tarefas.Add(residencial);
            db.SaveChanges();
            AuxDao.deleteTrash();
            return Ok();
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