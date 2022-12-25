using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendCartridges2.Models
{
    [Table("Ranks")]
    public class Rank
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<User> Users { get; set; } = new List<User>();
    }
}
