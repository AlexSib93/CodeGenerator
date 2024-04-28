using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_pollexecutingsign_idpeople")]
    [Index("idpollexecuting", Name = "idx_pollexecutingsign_idpollexecuting")]
    [Index("idsign", Name = "idx_pollexecutingsign_idsign")]
    public partial class pollexecutingsign
    {
        [Key]
        public int idpollexecutingsign { get; set; }
        public int? idpollexecuting { get; set; }
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

        [ForeignKey("idpeople")]
        [InverseProperty("pollexecutingsign")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idpollexecuting")]
        [InverseProperty("pollexecutingsign")]
        public virtual pollexecuting? idpollexecutingNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("pollexecutingsign")]
        public virtual sign? idsignNavigation { get; set; }
    }
}
