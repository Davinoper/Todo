using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoFriends.Models
{
    public enum Acao
    {
       CADASTRO_TAREFA,
       CADASTRO_LOCAL,
       CADASTRO_HORARIO
    }
    public class Log
    {

        public int Id { get; set; }
        public DateTime HoraCadastro { get; set; }

        public Acao Acao { get; set; }

    }
}