using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idagreement", Name = "idx_agreementgrant_idagreement")]
    [Index("idpeoplegroup", Name = "idx_agreementgrant_idpeoplegroup")]
    public partial class agreementgrant
    {
        [Key]
        public int idagreementgrant { get; set; }
        public int idpeoplegroup { get; set; }
        public int idagreement { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool grant { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idagreement")]
        [InverseProperty("agreementgrant")]
        public virtual agreement idagreementNavigation { get; set; } = null!;
        [ForeignKey("idpeoplegroup")]
        [InverseProperty("agreementgrant")]
        public virtual peoplegroup idpeoplegroupNavigation { get; set; } = null!;
    }
}
