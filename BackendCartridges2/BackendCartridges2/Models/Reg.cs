using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendCartridges2.Models
{
    [Table("Regs")]
    public class Reg
    {
        public int Id { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime AuthDate { get; set; }

        [JsonIgnore]
        //public virtual IEnumerable<User> Users { get; set; } = new List<User>();
        public virtual User Users { get; set; } = new User();
    }
}
