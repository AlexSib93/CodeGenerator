using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__colorgroup__54582A71", IsUnique = true)]
    [Index("parentid", Name = "idx_colorgroup_parentid")]
    public partial class colorgroup
    {
        public colorgroup()
        {
            color = new HashSet<color>();
        }

        [Key]
        public int idcolorgroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? parentid { get; set; }
        public short? isactive { get; set; }
        public Guid guid { get; set; }
        public int? numpos { get; set; }
        [StringLength(128)]
        public string? name_strkey { get; set; }

        [InverseProperty("idcolorgroupNavigation")]
        public virtual ICollection<color> color { get; set; }
    }
}
