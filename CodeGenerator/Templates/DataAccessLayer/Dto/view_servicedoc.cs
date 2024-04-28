using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_servicedoc
    {
        public int idservicedoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smdoc { get; set; }
        public int? idpeople { get; set; }
        public int? idcustomer { get; set; }
        public int? iddocoper { get; set; }
        public int? idservicereason { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? contact { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? phone { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? address { get; set; }
        public int? idservicedocgroup { get; set; }
        public int? idorder { get; set; }
        public int? idaddress { get; set; }
        public int? idorderdest { get; set; }
        public int? iddepartment { get; set; }
        public int? parentid { get; set; }
        public int? iddocstate { get; set; }
        public int? iddestanation { get; set; }
        public int? addint1 { get; set; }
        public int? addint2 { get; set; }
        public int? addint3 { get; set; }
        public int? addint4 { get; set; }
        public int? addint5 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum5 { get; set; }
        [Unicode(false)]
        public string? addstr1 { get; set; }
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [Unicode(false)]
        public string? addstr3 { get; set; }
        [Unicode(false)]
        public string? addstr4 { get; set; }
        [Unicode(false)]
        public string? addstr5 { get; set; }
        [Unicode(false)]
        public string? resolution { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? reason_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docoper_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_agreename { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderdest_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderdest_agreename { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? department_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docstate_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? destanation_name { get; set; }
    }
}
