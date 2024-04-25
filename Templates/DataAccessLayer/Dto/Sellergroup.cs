using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__sellergroup__171A1207", IsUnique = true)]
    [Index("parentid", Name = "idx_sellergroup_parentid")]
    public partial class sellergroup
    {
        public sellergroup()
        {
            seller = new HashSet<seller>();
        }

        [Key]
        public int idsellergroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? parentid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idsellergroupNavigation")]
        public virtual ICollection<seller> seller { get; set; }
    }
}
