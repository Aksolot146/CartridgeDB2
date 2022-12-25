using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrontendCartridges.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(32, ErrorMessage = "Login name too long (32 character limit)")]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [StringLength(128, ErrorMessage = "Email name too long (128 character limit)")]
        public string Mail { get; set; }
        public int RankId { get; set; }
        public int RegId { get; set; }

        [ForeignKey("RankId")]
        public virtual Rank Rank { get; set; }

        [ForeignKey("RegId")]
        public virtual Reg Reg { get; set; }
    }
}
