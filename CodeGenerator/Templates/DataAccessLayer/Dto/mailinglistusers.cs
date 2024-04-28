using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmailinglist", Name = "idx_idmailinglist")]
    [Index("idcustomer", Name = "idx_mailinglistusers_idcustomer")]
    [Index("idpeople", Name = "idx_mailinglistusers_idpeople")]
    public partial class mailinglistusers
    {
        [Key]
        public int idmailinglistusers { get; set; }
        public int idmailinglist { get; set; }
        public int? idcustomer { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("mailinglistusers")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("idmailinglist")]
        [InverseProperty("mailinglistusers")]
        public virtual mailinglist idmailinglistNavigation { get; set; } = null!;
        [ForeignKey("idpeople")]
        [InverseProperty("mailinglistusers")]
        public virtual people? idpeopleNavigation { get; set; }
    }
}
