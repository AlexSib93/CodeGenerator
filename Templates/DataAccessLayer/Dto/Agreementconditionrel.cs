using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idagreement", Name = "idx_agreementconditionrel_idagreement")]
    [Index("idagreementcondition", Name = "idx_agreementconditionrel_idagreementcondition")]
    public partial class agreementconditionrel
    {
        [Key]
        public int idagreementconditionrel { get; set; }
        public int idagreement { get; set; }
        public int idagreementcondition { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal value { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool? flag { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        [Unicode(false)]
        public string? strvalue { get; set; }

        [ForeignKey("idagreement")]
        [InverseProperty("agreementconditionrel")]
        public virtual agreement idagreementNavigation { get; set; } = null!;
        [ForeignKey("idagreementcondition")]
        [InverseProperty("agreementconditionrel")]
        public virtual agreementcondition idagreementconditionNavigation { get; set; } = null!;
    }
}
