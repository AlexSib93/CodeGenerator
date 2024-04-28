using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_productiondocgroup_parentid")]
    public partial class productiondocgroup
    {
        public productiondocgroup()
        {
            productiondoc = new HashSet<productiondoc>();
        }

        [Key]
        public int idproductiondocgroup { get; set; }
        public int? parentid { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public short? typ { get; set; }
        [Column(TypeName = "text")]
        public string? filtertext { get; set; }
        public int? numpos { get; set; }
        public short? isload { get; set; }

        [InverseProperty("idproductiondocgroupNavigation")]
        public virtual ICollection<productiondoc> productiondoc { get; set; }
    }
}
