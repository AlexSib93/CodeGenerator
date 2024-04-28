using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idreport", Name = "idx_reportsave_idreport")]
    public partial class reportsave
    {
        [Key]
        public int idreportsave { get; set; }
        public int? idreport { get; set; }
        public byte[]? report { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? savedate { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? reportgroup { get; set; }

        [ForeignKey("idreport")]
        [InverseProperty("reportsave")]
        public virtual report? idreportNavigation { get; set; }
    }
}
