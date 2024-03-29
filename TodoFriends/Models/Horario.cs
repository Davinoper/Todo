﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodoFriends.Models
{
    [Table("Horario")]
    public class Horario
    {
        [Key]
        public int Id { get; set; }
  
        [StringLength(15)]
        public string Apelido { get; set; }
 
        public DateTime Date { get; set; }
    }
}