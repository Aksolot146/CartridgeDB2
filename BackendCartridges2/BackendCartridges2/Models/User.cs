using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendCartridges2.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public int RankId { get; set; }
        public int RegId { get; set; }

        [ForeignKey("RankId")]
        public virtual Rank Rank { get; set; }

        [ForeignKey("RegId")]
        public virtual Reg Reg { get; set; }
    }
}
