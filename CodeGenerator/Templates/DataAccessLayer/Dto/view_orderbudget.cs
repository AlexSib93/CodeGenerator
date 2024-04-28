using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_orderbudget
    {
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
        [StringLength(256)]
        [Unicode(false)]
        public string? budget_name { get; set; }
        public int? budget_numpos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? budget_d { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? budget_k { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? budget_perc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? budget_part { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? budgetgroup_name { get; set; }
    }
}
