using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idseller", Name = "idx_agreement_idseller")]
    [Index("idvalut", Name = "idx_agreement_idvalut")]
    public partial class agreement
    {
        public agreement()
        {
            agreementconditionrel = new HashSet<agreementconditionrel>();
            agreementgrant = new HashSet<agreementgrant>();
            customer = new HashSet<customer>();
            customeragreement = new HashSet<customeragreement>();
            orders = new HashSet<orders>();
        }

        [Key]
        public int idagreement { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string name { get; set; } = null!;
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtstart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtend { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idseller { get; set; }
        public int? idvalut { get; set; }

        [ForeignKey("idseller")]
        [InverseProperty("agreement")]
        public virtual seller? idsellerNavigation { get; set; }
        [ForeignKey("idvalut")]
        [InverseProperty("agreement")]
        public virtual valut? idvalutNavigation { get; set; }
        [InverseProperty("idagreementNavigation")]
        public virtual ICollection<agreementconditionrel> agreementconditionrel { get; set; }
        [InverseProperty("idagreementNavigation")]
        public virtual ICollection<agreementgrant> agreementgrant { get; set; }
        [InverseProperty("idagreementNavigation")]
        public virtual ICollection<customer> customer { get; set; }
        [InverseProperty("idagreementNavigation")]
        public virtual ICollection<customeragreement> customeragreement { get; set; }
        [InverseProperty("idagreementNavigation")]
        public virtual ICollection<orders> orders { get; set; }
    }
}
