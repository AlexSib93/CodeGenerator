using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddocoper", Name = "idx_revisiongp_iddocoper")]
    [Index("iddocstate", Name = "idx_revisiongp_iddocstate")]
    [Index("idpeople", Name = "idx_revisiongp_idpeople")]
    [Index("idstoredepart", Name = "idx_revisiongp_idstoredepart")]
    public partial class revisiongp
    {
        public revisiongp()
        {
            revisiongpitem = new HashSet<revisiongpitem>();
        }

        [Key]
        public int idrevisiongp { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime dtdoc { get; set; }
        public int idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime dtcre { get; set; }
        public int? iddocoper { get; set; }
        public int? iddocstate { get; set; }
        public int? idstoredepart { get; set; }
        public bool? reg { get; set; }

        [ForeignKey("iddocoper")]
        [InverseProperty("revisiongp")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("revisiongp")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("revisiongp")]
        public virtual people idpeopleNavigation { get; set; } = null!;
        [ForeignKey("idstoredepart")]
        [InverseProperty("revisiongp")]
        public virtual storedepart? idstoredepartNavigation { get; set; }
        [InverseProperty("idrevisiongpNavigation")]
        public virtual ICollection<revisiongpitem> revisiongpitem { get; set; }
    }
}
