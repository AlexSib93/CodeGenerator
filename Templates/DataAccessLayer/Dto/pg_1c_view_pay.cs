using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class pg_1c_view_pay
    {
        [StringLength(128)]
        [Unicode(false)]
        public string? p_name { get; set; }
        public int idpaymentdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        public int? idorder { get; set; }
        public int? idsupplydoc { get; set; }
        public int? iddocoper { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docoper_name { get; set; }
        public int? idpaymentgroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? paymentgroup_name { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut_shortname { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smdoc { get; set; }
        [StringLength(31)]
        [Unicode(false)]
        public string? idcustomer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt_check { get; set; }
    }
}
