using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoFriends.Models
{
    public class Comodo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [JsonIgnore]
        public virtual ICollection<Residencial> Residenciais { get; set; }

    }
}