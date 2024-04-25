using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_manufactdocgroup_parentid")]
    public partial class manufactdocgroup
    {
        public manufactdocgroup()
        {
            manufactdoc = new HashSet<manufactdoc>();
        }

        [Key]
        public int idmanufactdocgroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? parentid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public short typ { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "text")]
        public string? filtertext { get; set; }
        public short? isload { get; set; }

        [InverseProperty("idmanufactdocgroupNavigation")]
        public virtual ICollection<manufactdoc> manufactdoc { get; set; }
    }
}
