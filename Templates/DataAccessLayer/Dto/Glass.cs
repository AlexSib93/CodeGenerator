using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__glass__6F0C20AD", IsUnique = true)]
    [Index("idglassgroup", Name = "idx_glass_idglassgroup")]
    public partial class glass
    {
        public glass()
        {
            glassdetail = new HashSet<glassdetail>();
            pf_glass_source_glass = new HashSet<pf_glass_source_glass>();
            pf_ms = new HashSet<pf_ms>();
            pf_stv = new HashSet<pf_stv>();
        }

        [Key]
        public int idglass { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? color { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? glassgroup { get; set; }
        public int? ramkaoffset { get; set; }
        public int? numpos { get; set; }
        public int? thickness { get; set; }
        public int? camernost { get; set; }
        public int? idglassgroup { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? marking2 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? marking3 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? marking4 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? marking5 { get; set; }
        public Guid guid { get; set; }
        public int? idfilltype { get; set; }

        [ForeignKey("idglassgroup")]
        [InverseProperty("glass")]
        public virtual glassgroup? idglassgroupNavigation { get; set; }
        [InverseProperty("idglassNavigation")]
        public virtual ICollection<glassdetail> glassdetail { get; set; }
        [InverseProperty("idglassNavigation")]
        public virtual ICollection<pf_glass_source_glass> pf_glass_source_glass { get; set; }
        [InverseProperty("idglassNavigation")]
        public virtual ICollection<pf_ms> pf_ms { get; set; }
        [InverseProperty("idglassNavigation")]
        public virtual ICollection<pf_stv> pf_stv { get; set; }
    }
}
