using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodoFriends.Models
{
    [Table("Local")]
    public class Local
    {
        [Key]

        public int Id { get; set; }
       
        public string Name { get; set; }

        [StringLength(25)]
        public string Rua { get; set; }
 
        [StringLength(25)]
        public string Bairro { get; set; }
     
        [StringLength(25)]
        public string Lote { get; set; }
    
        [StringLength(25)]
        public string Qi { get; set; }
    }
}