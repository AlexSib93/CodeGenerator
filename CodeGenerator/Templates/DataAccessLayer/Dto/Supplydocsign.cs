using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_supplydocsign_idpeople")]
    [Index("idsign", Name = "idx_supplydocsign_idsign")]
    [Index("idsupplydoc", Name = "idx_supplydocsign_idsupplydoc")]
    [Index("idsupplydocpos", Name = "idx_supplydocsign_idsupplydocpos")]
    public partial class supplydocsign
    {
        [Key]
        public int idsupplydocsign { get; set; }
        public int? idsupplydoc { get; set; }
        public int? idsign { get; set; }
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
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue2 { get; set; }
        public int? idsupplydocpos { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("supplydocsign")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("supplydocsign")]
        public virtual sign? idsignNavigation { get; set; }
        [ForeignKey("idsupplydoc")]
        [InverseProperty("supplydocsign")]
        public virtual supplydoc? idsupplydocNavigation { get; set; }
        [ForeignKey("idsupplydocpos")]
        [InverseProperty("supplydocsign")]
        public virtual supplydocpos? idsupplydocposNavigation { get; set; }
    }
}
