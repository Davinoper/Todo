﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodoFriends.Models
{
    [Table("Tarefa_Residencial")]
    public class Residencial : Tarefa
    {
     
        [StringLength(20)]
        public string comodo { get; set; }
       
      
    }
}