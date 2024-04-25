using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_mailinglistondemand_idcustomer")]
    [Index("idmailinglist", Name = "idx_mailinglistondemand_idmailinglist")]
    [Index("idpeople", Name = "idx_mailinglistondemand_idpeople")]
    public partial class mailinglistondemand
    {
        [Key]
        public int idmailinglistondemand { get; set; }
        public int idmailinglist { get; set; }
        public int? idcustomer { get; set; }
        public int? idpeople { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? message { get; set; }
        [Column("params", TypeName = "text")]
        public string? _params { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime dtcreate { get; set; }
        public bool completed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("mailinglistondemand")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("idmailinglist")]
        [InverseProperty("mailinglistondemand")]
        public virtual mailinglist idmailinglistNavigation { get; set; } = null!;
        [ForeignKey("idpeople")]
        [InverseProperty("mailinglistondemand")]
        public virtual people? idpeopleNavigation { get; set; }
    }
}
