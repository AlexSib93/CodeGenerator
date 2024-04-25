using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_storedocsign_idpeople")]
    [Index("idsign", Name = "idx_storedocsign_idsign")]
    [Index("idstoredoc", Name = "idx_storedocsign_idstoredoc")]
    [Index("idstoredocpos", Name = "idx_storedocsign_idstoredocpos")]
    public partial class storedocsign
    {
        [Key]
        public int idstoredocsign { get; set; }
        public int? idstoredoc { get; set; }
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
        public int? idstoredocpos { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("storedocsign")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("storedocsign")]
        public virtual sign? idsignNavigation { get; set; }
        [ForeignKey("idstoredoc")]
        [InverseProperty("storedocsign")]
        public virtual storedoc? idstoredocNavigation { get; set; }
        [ForeignKey("idstoredocpos")]
        [InverseProperty("storedocsign")]
        public virtual storedocpos? idstoredocposNavigation { get; set; }
    }
}
