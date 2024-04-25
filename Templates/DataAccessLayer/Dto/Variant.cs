using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idconnection", Name = "idx_variant_idconnection")]
    [Index("idvarianttype", Name = "idx_variant_idvarianttype")]
    public partial class variant
    {
        public variant()
        {
            variantdetail = new HashSet<variantdetail>();
            variantparam = new HashSet<variantparam>();
        }

        [Key]
        public int idvariant { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string name { get; set; } = null!;
        public int numpos { get; set; }
        public byte? type { get; set; }
        public int idconnection { get; set; }
        public int? idvarianttype { get; set; }

        [ForeignKey("idconnection")]
        [InverseProperty("variant")]
        public virtual connection idconnectionNavigation { get; set; } = null!;
        [ForeignKey("idvarianttype")]
        [InverseProperty("variant")]
        public virtual varianttype? idvarianttypeNavigation { get; set; }
        [InverseProperty("idvariantNavigation")]
        public virtual ICollection<variantdetail> variantdetail { get; set; }
        [InverseProperty("idvariantNavigation")]
        public virtual ICollection<variantparam> variantparam { get; set; }
    }
}
