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
    public class TarefaController : ApiController
    {
        private TodoFriensContext db = new TodoFriensContext();

        // GET: api/Tarefa
        [NonAction]
        public IQueryable<Tarefa> GetTarefas()
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            
            foreach (var item in db.Tarefas)
            {
                item.Horario = db.Horarios.Find(HorarioDao.findIdByTarefa(item));
                item.Usuario = db.Usuarios.Find(UsuarioDao.findIdByTarefa(item));

                if (LocalDao.containLocal(item))
                {
                    Externa ex = (Externa) item;
                    ex.Local = db.Locais.Find(LocalDao.findIdByTarefa(ex));
                    tarefas.Add(ex);
                }
                tarefas.Add(item);
               
   
            }
            IQueryable<Tarefa> tarefas2 = tarefas.AsQueryable();
            return tarefas2;
        }

        // GET: api/Tarefa?idusu=1

  
        [HttpGet]
        [ActionName("getbyusuario")]
        public IQueryable<Tarefa> GetByUsuario([FromUri]int idusu)
        {
            List<Tarefa> tarefas = new List<Tarefa>();
           
            foreach (var item in db.Tarefas)
            {
                item.Horario = db.Horarios.Find(HorarioDao.findIdByTarefa(item));
                item.Usuario = db.Usuarios.Find(UsuarioDao.findIdByTarefa(item));

                if (item.Usuario.Id == idusu)
                {
                    
                    if (LocalDao.containLocal(item))
                    {
                        Externa ex = (Externa)item;
                        ex.Local = db.Locais.Find(LocalDao.findIdByTarefa(ex));
                        tarefas.Add(ex);
                    }

                    tarefas.Add(item);
                }
            }
            IQueryable<Tarefa> tarefas2 = tarefas.AsQueryable();
            return tarefas2;
        }

        // GET: api/Tarefa/5
        [NonAction]
        [ResponseType(typeof(Tarefa))]
        public IHttpActionResult GetTarefa(int id)
        {
            Tarefa tarefa = db.Tarefas.Find(id);

            if (tarefa == null)
            {
                return NotFound();
            }
            tarefa.Horario = db.Horarios.Find(HorarioDao.findIdByTarefa(tarefa));
            tarefa.Usuario = db.Usuarios.Find(UsuarioDao.findIdByTarefa(tarefa));

            if (LocalDao.containLocal(tarefa))
            {
                Externa tarefa2 = (Externa)tarefa;
                tarefa2.Local = db.Locais.Find(LocalDao.findIdByTarefa(tarefa2));
                return Ok(tarefa2);
            }


            return Ok(tarefa);
        }

        // DELETE: api/Tarefa/5
        [ResponseType(typeof(Tarefa))]
        public IHttpActionResult DeleteTarefa(int id)
        {
            Tarefa tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            db.Tarefas.Remove(tarefa);
            db.SaveChanges();

            return Ok(tarefa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TarefaExists(int id)
        {
            return db.Tarefas.Count(e => e.Id == id) > 0;
        }

        
    }
}