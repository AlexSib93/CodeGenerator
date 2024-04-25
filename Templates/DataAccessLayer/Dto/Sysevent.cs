using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class sysevent
    {
        public int id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        public int? idpeople { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? message { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? barcode { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? eventname { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue3 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? strvalue1 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? strvalue2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? strvalue3 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue3 { get; set; }
    }
}
