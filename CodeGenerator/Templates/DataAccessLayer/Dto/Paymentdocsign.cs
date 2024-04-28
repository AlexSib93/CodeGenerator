using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpaymentdoc", Name = "idx_paymentdocsign_idpaymentdoc")]
    [Index("idpeople", Name = "idx_paymentdocsign_idpeople")]
    [Index("idsign", Name = "idx_paymentdocsign_idsign")]
    public partial class paymentdocsign
    {
        [Key]
        public int idpaymentdocsign { get; set; }
        public int? idpaymentdoc { get; set; }
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

        [ForeignKey("idpaymentdoc")]
        [InverseProperty("paymentdocsign")]
        public virtual paymentdoc? idpaymentdocNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("paymentdocsign")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("paymentdocsign")]
        public virtual sign? idsignNavigation { get; set; }
    }
}
