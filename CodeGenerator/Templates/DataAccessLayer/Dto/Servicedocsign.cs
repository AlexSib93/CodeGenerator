using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idorderitem", Name = "idx_servicedocsign_idorderitem")]
    [Index("idpeople", Name = "idx_servicedocsign_idpeople")]
    [Index("idservicedoc", Name = "idx_servicedocsign_idservicedoc")]
    [Index("idsign", Name = "idx_servicedocsign_idsign")]
    public partial class servicedocsign
    {
        [Key]
        public int idservicedocsign { get; set; }
        public int? idservicedoc { get; set; }
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
        public int? idorderitem { get; set; }

        [ForeignKey("idorderitem")]
        [InverseProperty("servicedocsign")]
        public virtual servicedocpos? idorderitemNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("servicedocsign")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idservicedoc")]
        [InverseProperty("servicedocsign")]
        public virtual servicedoc? idservicedocNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("servicedocsign")]
        public virtual sign? idsignNavigation { get; set; }
    }
}
