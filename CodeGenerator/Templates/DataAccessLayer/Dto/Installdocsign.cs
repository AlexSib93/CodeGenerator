using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idinstalldoc", Name = "idx_installdocsign_idinstalldoc")]
    [Index("idpeople", Name = "idx_installdocsign_idpeople")]
    [Index("idsign", Name = "idx_installdocsign_idsign")]
    [Index("idsignvalue", Name = "idx_installdocsign_idsignvalue")]
    public partial class installdocsign
    {
        [Key]
        public int idinstalldocsign { get; set; }
        public int? idinstalldoc { get; set; }
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

        [ForeignKey("idinstalldoc")]
        [InverseProperty("installdocsign")]
        public virtual installdoc? idinstalldocNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("installdocsign")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("installdocsign")]
        public virtual sign? idsignNavigation { get; set; }
        [ForeignKey("idsignvalue")]
        [InverseProperty("installdocsign")]
        public virtual signvalue? idsignvalueNavigation { get; set; }
    }
}
