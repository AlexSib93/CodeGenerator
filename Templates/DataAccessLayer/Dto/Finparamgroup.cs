using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__finparamgroup__70F4691F", IsUnique = true)]
    [Index("parentid", Name = "idx_finparamgroup_parentid")]
    public partial class finparamgroup
    {
        public finparamgroup()
        {
            finparam = new HashSet<finparam>();
        }

        [Key]
        public int idfinparamgroup { get; set; }
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
        public int? idversion { get; set; }
        public Guid guid { get; set; }
        public int? typ { get; set; }

        [InverseProperty("idfinparamgroupNavigation")]
        public virtual ICollection<finparam> finparam { get; set; }
    }
}
