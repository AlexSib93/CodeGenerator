using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddocoper", Name = "idx_reportdocoper_iddocoper")]
    [Index("idpeoplegroup", Name = "idx_reportdocoper_idpeoplegroup")]
    [Index("idreport", Name = "idx_reportdocoper_idreport")]
    public partial class reportdocoper
    {
        [Key]
        public int idreportdocoper { get; set; }
        public int? idreport { get; set; }
        public int? iddocoper { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idpeoplegroup { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("iddocoper")]
        [InverseProperty("reportdocoper")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("idpeoplegroup")]
        [InverseProperty("reportdocoper")]
        public virtual peoplegroup? idpeoplegroupNavigation { get; set; }
        [ForeignKey("idreport")]
        [InverseProperty("reportdocoper")]
        public virtual report? idreportNavigation { get; set; }
    }
}
