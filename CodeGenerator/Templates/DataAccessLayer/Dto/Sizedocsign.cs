using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class sizedocsign
    {
        public int? idsizedocsign { get; set; }
        public int? idsizedoc { get; set; }
        public int? idsign { get; set; }
        public int? idsignvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [Unicode(false)]
        public string? strvalue { get; set; }
        [Column(TypeName = "numeric(15, 5)")]
        public decimal? intvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue2 { get; set; }

        [ForeignKey("idpeople")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idsign")]
        public virtual sign? idsignNavigation { get; set; }
        [ForeignKey("idsignvalue")]
        public virtual signvalue? idsignvalueNavigation { get; set; }
        [ForeignKey("idsizedoc")]
        public virtual sizedoc? idsizedocNavigation { get; set; }
    }
}
