using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idbudgetgroup", Name = "idx_budget_idbudgetgroup")]
    public partial class budget
    {
        public budget()
        {
            orderbudget = new HashSet<orderbudget>();
        }

        [Key]
        public int idbudget { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? part { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idbudgetgroup { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? d { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? k { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? perc { get; set; }
        public int? numpos { get; set; }
        public short? autosave { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idbudgetgroup")]
        [InverseProperty("budget")]
        public virtual budgetgroup? idbudgetgroupNavigation { get; set; }
        [InverseProperty("idbudgetNavigation")]
        public virtual ICollection<orderbudget> orderbudget { get; set; }
    }
}
