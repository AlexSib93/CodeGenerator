using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddiscardgroup", Name = "idx_discard_iddiscardgroup")]
    [Index("idpeople", Name = "idx_discard_idpeople")]
    public partial class discard
    {
        public discard()
        {
            customerdiscard = new HashSet<customerdiscard>();
            orderdiscard = new HashSet<orderdiscard>();
            orders = new HashSet<orders>();
        }

        [Key]
        public int iddiscard { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? inactivedate { get; set; }
        public int? idpeople { get; set; }
        public int? iddiscardgroup { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? perc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("iddiscardgroup")]
        [InverseProperty("discard")]
        public virtual discardgroup? iddiscardgroupNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("discard")]
        public virtual people? idpeopleNavigation { get; set; }
        [InverseProperty("iddiscardNavigation")]
        public virtual ICollection<customerdiscard> customerdiscard { get; set; }
        [InverseProperty("iddiscardNavigation")]
        public virtual ICollection<orderdiscard> orderdiscard { get; set; }
        [InverseProperty("iddiscardNavigation")]
        public virtual ICollection<orders> orders { get; set; }
    }
}
