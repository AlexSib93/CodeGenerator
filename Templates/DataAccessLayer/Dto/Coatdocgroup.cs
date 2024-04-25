using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_coatdocgroup_parentid")]
    public partial class coatdocgroup
    {
        [Key]
        public int idcoatdocgroup { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? parentid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? typ { get; set; }
        [Column(TypeName = "text")]
        public string? filtertext { get; set; }
        public int? numpos { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        public short? isload { get; set; }
    }
}
