using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idreportgroup", Name = "idx_report_idreportgroup")]
    [Index("idreportscript", Name = "idx_report_idreportscript")]
    public partial class report
    {
        public report()
        {
            mailinglist = new HashSet<mailinglist>();
            reportdocoper = new HashSet<reportdocoper>();
            reportkitdetail = new HashSet<reportkitdetail>();
            reportsave = new HashSet<reportsave>();
        }

        [Key]
        public int idreport { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? reportgroup { get; set; }
        public byte[]? dll { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? filename { get; set; }
        [Column("report")]
        public byte[]? report1 { get; set; }
        public short? loadtype { get; set; }
        public int? numpos { get; set; }
        public int? idreportgroup { get; set; }
        public short? isactive { get; set; }
        public int? idreportscript { get; set; }
        /// <summary>
        /// Переносить в дилерскую версию
        /// </summary>
        public bool? indealerbase { get; set; }
        public Guid guid { get; set; }
        public bool tomenu { get; set; }
        public byte[]? picture { get; set; }

        [ForeignKey("idreportgroup")]
        [InverseProperty("report")]
        public virtual reportgroup? idreportgroupNavigation { get; set; }
        [ForeignKey("idreportscript")]
        [InverseProperty("report")]
        public virtual reportscript? idreportscriptNavigation { get; set; }
        [InverseProperty("idreportNavigation")]
        public virtual ICollection<mailinglist> mailinglist { get; set; }
        [InverseProperty("idreportNavigation")]
        public virtual ICollection<reportdocoper> reportdocoper { get; set; }
        [InverseProperty("idreportNavigation")]
        public virtual ICollection<reportkitdetail> reportkitdetail { get; set; }
        [InverseProperty("idreportNavigation")]
        public virtual ICollection<reportsave> reportsave { get; set; }
    }
}
