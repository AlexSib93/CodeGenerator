using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_optimdocgroup_parentid")]
    public partial class optimdocgroup
    {
        public optimdocgroup()
        {
            optimdoc = new HashSet<optimdoc>();
        }

        [Key]
        public int idoptimdocgroup { get; set; }
        public int? parentid { get; set; }
        public int? numpos { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        public short? typ { get; set; }
        [Column(TypeName = "text")]
        public string? filtertext { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        public short? isload { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [InverseProperty("idoptimdocgroupNavigation")]
        public virtual ICollection<optimdoc> optimdoc { get; set; }
    }
}
