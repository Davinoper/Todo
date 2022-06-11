using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodoFriends.Models
{
    [Table("Tarefa_Externa")]
    public class Externa : Tarefa
    {
        [Required]
        public Local Local { get; set; }

      
    }
}