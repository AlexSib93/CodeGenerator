using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idbudget", Name = "idx_orderbudget_idbudget")]
    [Index("idorder", Name = "idx_orderbudget_idorder")]
    public partial class orderbudget
    {
        [Key]
        public int idorderbudget { get; set; }
        public int? idorder { get; set; }
        public int? idbudget { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? d { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? k { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? perc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idbudget")]
        [InverseProperty("orderbudget")]
        public virtual budget? idbudgetNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("orderbudget")]
        public virtual orders? idorderNavigation { get; set; }
    }
}
