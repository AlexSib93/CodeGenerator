using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class payment
    {
        public int idpayment { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        public int? idcustomer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smdoc { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? logincre { get; set; }
        public int? idorder { get; set; }
        public int? idpaymentgroup { get; set; }
        public int? iddocoper { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? idpaymentdocgroup { get; set; }
        public int? idseller { get; set; }
        public Guid guid { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? addstr { get; set; }
        public int? idsupplydoc { get; set; }
        public int? iddocstate { get; set; }
        public int? idcashbox { get; set; }
    }
}
