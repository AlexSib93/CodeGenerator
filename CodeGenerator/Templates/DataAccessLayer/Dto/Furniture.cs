using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__furniture__6231487C", IsUnique = true)]
    [Index("parentid", Name = "idx_furniture_parentid")]
    public partial class furniture
    {
        [Key]
        public int idfurniture { get; set; }
        public int? numpos { get; set; }
        public int? parentid { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? name { get; set; }
        public bool? isactive { get; set; }
        public bool? issignificant { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool? isstandartname { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? standartname { get; set; }
        public bool? iscode { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? codename { get; set; }
        [Column(TypeName = "text")]
        public string? codescript { get; set; }
        public bool? ispoint { get; set; }
        public int? pointid { get; set; }
        public Guid guid { get; set; }
        public bool? ischecked { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? errorstring { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? warningstring { get; set; }
    }
}
