using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__diractiongroup__09C016E9", IsUnique = true)]
    [Index("parentid", Name = "idx_diractiongroup_parentid")]
    public partial class diractiongroup
    {
        public diractiongroup()
        {
            diraction = new HashSet<diraction>();
        }

        [Key]
        public int iddiractiongroup { get; set; }
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

        [InverseProperty("iddiractiongroupNavigation")]
        public virtual ICollection<diraction> diraction { get; set; }
    }
}
