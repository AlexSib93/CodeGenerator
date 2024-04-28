using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idoptimdoc", Name = "idx_optimdocsign_idoptimdoc")]
    [Index("idorderitem", Name = "idx_optimdocsign_idorderitem")]
    [Index("idpeople", Name = "idx_optimdocsign_idpeople")]
    [Index("idsign", Name = "idx_optimdocsign_idsign")]
    [Index("idsignvalue", Name = "idx_optimdocsign_idsignvalue")]
    public partial class optimdocsign
    {
        [Key]
        public int idoptimdocsign { get; set; }
        public int? idoptimdoc { get; set; }
        public int? idsign { get; set; }
        public int? idsignvalue { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Unicode(false)]
        public string? strvalue { get; set; }
        [Column(TypeName = "numeric(15, 5)")]
        public decimal? intvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue2 { get; set; }
        public int? idorderitem { get; set; }

        [ForeignKey("idoptimdoc")]
        [InverseProperty("optimdocsign")]
        public virtual optimdoc? idoptimdocNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("optimdocsign")]
        public virtual optimdocpos? idorderitemNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("optimdocsign")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("optimdocsign")]
        public virtual sign? idsignNavigation { get; set; }
        [ForeignKey("idsignvalue")]
        [InverseProperty("optimdocsign")]
        public virtual signvalue? idsignvalueNavigation { get; set; }
    }
}
