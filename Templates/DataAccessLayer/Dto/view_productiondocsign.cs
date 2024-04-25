using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_productiondocsign
    {
        public int idproductiondocsign { get; set; }
        public int? idproductiondoc { get; set; }
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
        [StringLength(128)]
        [Unicode(false)]
        public string? sign_name { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? signvalue_int { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? signvalue_str { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string people_fio { get; set; } = null!;
    }
}
