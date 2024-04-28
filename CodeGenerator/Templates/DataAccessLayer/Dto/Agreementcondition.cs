using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class agreementcondition
    {
        public agreementcondition()
        {
            agreementconditionrel = new HashSet<agreementconditionrel>();
        }

        [Key]
        public int idagreementcondition { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string name { get; set; } = null!;
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? defaultvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [InverseProperty("idagreementconditionNavigation")]
        public virtual ICollection<agreementconditionrel> agreementconditionrel { get; set; }
    }
}
