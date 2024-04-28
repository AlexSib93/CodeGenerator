using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcoatdoc", Name = "idx_coatdocsign_idcoatdoc")]
    [Index("idpeople", Name = "idx_coatdocsign_idpeople")]
    [Index("idsign", Name = "idx_coatdocsign_idsign")]
    public partial class coatdocsign
    {
        [Key]
        public int idcoatdocsign { get; set; }
        public int? idcoatdoc { get; set; }
        public int? idsign { get; set; }
        public int? idsignvalue { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        public int? idpeople { get; set; }
        [Unicode(false)]
        public string? strvalue { get; set; }
        [Column(TypeName = "numeric(15, 5)")]
        public decimal? intvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue2 { get; set; }

        [ForeignKey("idcoatdoc")]
        [InverseProperty("coatdocsign")]
        public virtual coatdoc? idcoatdocNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("coatdocsign")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("coatdocsign")]
        public virtual sign? idsignNavigation { get; set; }
    }
}
