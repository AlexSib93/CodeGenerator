using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_reportgroup_parentid")]
    public partial class reportgroup
    {
        public reportgroup()
        {
            report = new HashSet<report>();
        }

        [Key]
        public int idreportgroup { get; set; }
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
        public Guid guid { get; set; }
        public bool? indealerbase { get; set; }

        [InverseProperty("idreportgroupNavigation")]
        public virtual ICollection<report> report { get; set; }
    }
}
