using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__signgroup__0BA85F5B", IsUnique = true)]
    [Index("parentid", Name = "idx_signgroup_parentid")]
    public partial class signgroup
    {
        public signgroup()
        {
            sign = new HashSet<sign>();
        }

        [Key]
        public int idsigngroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? parentid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? isactive { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idsigngroupNavigation")]
        public virtual ICollection<sign> sign { get; set; }
    }
}
