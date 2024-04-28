using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__glasselement__5828BB55", IsUnique = true)]
    [Index("idglasselementgroup", Name = "idx_glasselement_idglasselementgroup")]
    public partial class glasselement
    {
        public glasselement()
        {
            glassdetail = new HashSet<glassdetail>();
            insertion = new HashSet<insertion>();
            pf_glass_source_ge = new HashSet<pf_glass_source_ge>();
        }

        [Key]
        public int idglasselement { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? marking { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? typ { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? thick { get; set; }
        public int? idglasselementgroup { get; set; }
        public Guid guid { get; set; }
        public int? ramkaoffset { get; set; }
        public int? color { get; set; }
        public int? numpos { get; set; }

        [ForeignKey("idglasselementgroup")]
        [InverseProperty("glasselement")]
        public virtual glasselementgroup? idglasselementgroupNavigation { get; set; }
        [InverseProperty("idglasselementNavigation")]
        public virtual ICollection<glassdetail> glassdetail { get; set; }
        [InverseProperty("idglasselementNavigation")]
        public virtual ICollection<insertion> insertion { get; set; }
        [InverseProperty("idglasselementNavigation")]
        public virtual ICollection<pf_glass_source_ge> pf_glass_source_ge { get; set; }
    }
}
