using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_orders_pricechange
    {
        public int idorder { get; set; }
        public int? idpeople { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? logincre { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        public int? idordersgroup { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        public int? idversion { get; set; }
        public int? idcustomer { get; set; }
        public int? iddocoper { get; set; }
        public int? qupos { get; set; }
        public int? idvalut { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? agreename { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? agreedate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? iddestanation { get; set; }
        public int? idseller { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? address { get; set; }
        public short? floor { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? contact { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? phone { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "text")]
        public string? addtext { get; set; }
        public short? saved { get; set; }
        public short? saved2 { get; set; }
        public int? idpeopleedit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? idaddress { get; set; }
        public int? iddiscard { get; set; }
        public int? idcustomer2 { get; set; }
        public int? idcustomer3 { get; set; }
        public int? idpeople2 { get; set; }
        public int? idpeople3 { get; set; }
        public int? idpeople4 { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        [Unicode(false)]
        public string? addinfo { get; set; }
        [Unicode(false)]
        public string? supplyinfo { get; set; }
        [Unicode(false)]
        public string? productinfo { get; set; }
        [Unicode(false)]
        public string? transportinfo { get; set; }
        [Unicode(false)]
        public string? installinfo { get; set; }
        [Unicode(false)]
        public string? sizeinfo { get; set; }
        public int? iddepartment { get; set; }
        public int? idsourceinfo { get; set; }
        public int? idadvertisingaction { get; set; }
        public int? addint1 { get; set; }
        public int? addint2 { get; set; }
        public int? addint3 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr1 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr3 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddt1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddt2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddt3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum3 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr4 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr5 { get; set; }
        public int? idparent { get; set; }
        public int? iddocstate { get; set; }
        public int? idagree { get; set; }
        public int? idpeopledesigner { get; set; }
        public int? idagreement { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? ordersgroup_name { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal customer_discount { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docoper_name { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut_shortname { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? destanation_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? seller_name { get; set; }
        [Column(TypeName = "numeric(38, 4)")]
        public decimal? pricechange_nac { get; set; }
        [Column(TypeName = "numeric(38, 4)")]
        public decimal? pricechange_skidka { get; set; }
        [Column(TypeName = "numeric(38, 4)")]
        public decimal? pricechange_skidka_oi { get; set; }
        [Column(TypeName = "numeric(38, 4)")]
        public decimal? sum_position_price { get; set; }
    }
}
