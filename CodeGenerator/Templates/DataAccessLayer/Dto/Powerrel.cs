using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpowermaster", Name = "idx_powerrel_idpowermaster")]
    [Index("idpowerslave", Name = "idx_powerrel_idpowerslave")]
    public partial class powerrel
    {
        [Key]
        public int idpowerrel { get; set; }
        public int idpowermaster { get; set; }
        public int idpowerslave { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? numpos { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? group { get; set; }

        [ForeignKey("idpowermaster")]
        [InverseProperty("powerrelidpowermasterNavigation")]
        public virtual power idpowermasterNavigation { get; set; } = null!;
        [ForeignKey("idpowerslave")]
        [InverseProperty("powerrelidpowerslaveNavigation")]
        public virtual power idpowerslaveNavigation { get; set; } = null!;
    }
}
