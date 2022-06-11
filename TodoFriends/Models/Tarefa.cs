using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodoFriends.Models
{
    [Table("Tarefa")]
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string descricao { get; set; }
        public Horario Horario { get; set; }
        public Usuario Usuario { get; set; }
    }
}