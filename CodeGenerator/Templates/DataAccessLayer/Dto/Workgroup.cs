using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__workgroup__4CB708A9", IsUnique = true)]
    [Index("parentid", Name = "idx_workgroup_parentid")]
    public partial class workgroup
    {
        public workgroup()
        {
            work = new HashSet<work>();
        }

        [Key]
        public int idworkgroup { get; set; }
        public int? parentid { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? isactive { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idworkgroupNavigation")]
        public virtual ICollection<work> work { get; set; }
    }
}
