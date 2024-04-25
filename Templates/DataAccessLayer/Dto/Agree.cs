using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_agree_idcustomer")]
    [Index("idpeople", Name = "idx_agree_idpeople")]
    public partial class agree
    {
        public agree()
        {
            orders = new HashSet<orders>();
        }

        [Key]
        public int idagree { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtstart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtend { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idcustomer { get; set; }
        public int? idpeople { get; set; }
        public int? addint { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("agree")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("agree")]
        public virtual people? idpeopleNavigation { get; set; }
        [InverseProperty("idagreeNavigation")]
        public virtual ICollection<orders> orders { get; set; }
    }
}
