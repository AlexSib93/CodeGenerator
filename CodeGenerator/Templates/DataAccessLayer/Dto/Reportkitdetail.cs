using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idreport", Name = "idx_reportkitdetail_idreport")]
    [Index("idreportkit", Name = "idx_reportkitdetail_idreportkit")]
    public partial class reportkitdetail
    {
        [Key]
        public int idreportkitdetail { get; set; }
        public int? idreport { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idreportkit { get; set; }
        public short? isprint { get; set; }
        public int? numpos { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idreport")]
        [InverseProperty("reportkitdetail")]
        public virtual report? idreportNavigation { get; set; }
        [ForeignKey("idreportkit")]
        [InverseProperty("reportkitdetail")]
        public virtual reportkit? idreportkitNavigation { get; set; }
    }
}
