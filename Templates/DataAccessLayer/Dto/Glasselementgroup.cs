using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__glasselementgrou__78958AE7", IsUnique = true)]
    [Index("parentid", Name = "idx_glasselementgroup_parentid")]
    public partial class glasselementgroup
    {
        public glasselementgroup()
        {
            glasselement = new HashSet<glasselement>();
        }

        [Key]
        public int idglasselementgroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? parentid { get; set; }
        public short? isactive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idglasselementgroupNavigation")]
        public virtual ICollection<glasselement> glasselement { get; set; }
    }
}
