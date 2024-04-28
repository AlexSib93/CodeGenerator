using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idorderitem", Name = "idx_manufactdocsign_idorderitem")]
    [Index("idpeople", Name = "idx_manufactdocsign_idpeople")]
    [Index("idmanufactdoc", Name = "idx_manufactsign_idmanufactdoc")]
    [Index("idsign", Name = "idx_manufactsign_idsign")]
    [Index("idsignvalue", Name = "idx_manufactsign_idsignvalue")]
    public partial class manufactdocsign
    {
        [Key]
        public int idmanufactdocsign { get; set; }
        public int? idsign { get; set; }
        public int? idmanufactdoc { get; set; }
        public int? idsignvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        public int? idpeople { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        [Unicode(false)]
        public string? strvalue { get; set; }
        [Column(TypeName = "numeric(15, 5)")]
        public decimal? intvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue2 { get; set; }
        public int? idorderitem { get; set; }

        [ForeignKey("idmanufactdoc")]
        [InverseProperty("manufactdocsign")]
        public virtual manufactdoc? idmanufactdocNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("manufactdocsign")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("manufactdocsign")]
        public virtual sign? idsignNavigation { get; set; }
        [ForeignKey("idsignvalue")]
        [InverseProperty("manufactdocsign")]
        public virtual signvalue? idsignvalueNavigation { get; set; }
    }
}
