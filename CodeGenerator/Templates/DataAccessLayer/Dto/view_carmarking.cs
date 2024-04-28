using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_carmarking
    {
        public int idcarmarking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? tonnage { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? tonnageue { get; set; }
        public int? width { get; set; }
        public int? length { get; set; }
        public int? maxroute { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? maxsqr { get; set; }
    }
}
