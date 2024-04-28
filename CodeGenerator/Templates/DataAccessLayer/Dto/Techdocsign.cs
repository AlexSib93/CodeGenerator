using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_techdocsign_idpeople")]
    [Index("idsign", Name = "idx_techdocsign_idsign")]
    [Index("idsignvalue", Name = "idx_techdocsign_idsignvalue")]
    [Index("idtechdoc", Name = "idx_techdocsign_idtechdoc")]
    public partial class techdocsign
    {
        [Key]
        public int idtechdocsign { get; set; }
        public int? idsign { get; set; }
        public int? idtechdoc { get; set; }
        public int? idsignvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        public int? idpeople { get; set; }
        [Unicode(false)]
        public string? strvalue { get; set; }
        [Column(TypeName = "numeric(15, 5)")]
        public decimal? intvalue { get; set; }
        public int? idtechdocpos { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue2 { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("techdocsign")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("techdocsign")]
        public virtual sign? idsignNavigation { get; set; }
        [ForeignKey("idsignvalue")]
        [InverseProperty("techdocsign")]
        public virtual signvalue? idsignvalueNavigation { get; set; }
        [ForeignKey("idtechdoc")]
        [InverseProperty("techdocsign")]
        public virtual techdoc? idtechdocNavigation { get; set; }
    }
}
