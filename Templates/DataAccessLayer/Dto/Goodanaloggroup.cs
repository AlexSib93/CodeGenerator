using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__goodanaloggroup__35D3A351", IsUnique = true)]
    [Index("parentid", Name = "idx_goodanaloggroup_parentid")]
    public partial class goodanaloggroup
    {
        public goodanaloggroup()
        {
            goodanalog = new HashSet<goodanalog>();
        }

        [Key]
        public int idgoodanaloggroup { get; set; }
        public int? parentid { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idgoodanaloggroupNavigation")]
        public virtual ICollection<goodanalog> goodanalog { get; set; }
    }
}
