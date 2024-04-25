using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__goodgroup__2E328189", IsUnique = true)]
    [Index("parentid", Name = "idx_goodgroup_parentid")]
    public partial class goodgroup
    {
        public goodgroup()
        {
            good = new HashSet<good>();
        }

        [Key]
        public int idgoodgroup { get; set; }
        public int? parentid { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public short? isactive { get; set; }
        public short? isvisible { get; set; }
        public int? numpos { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idgoodgroupNavigation")]
        public virtual ICollection<good> good { get; set; }
    }
}
