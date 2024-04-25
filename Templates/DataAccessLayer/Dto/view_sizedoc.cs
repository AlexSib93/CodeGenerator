using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_sizedoc
    {
        public int idsizedoc { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        public int? idpeople { get; set; }
        public int? idcustomer { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? iddocoper { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        public int? qupos { get; set; }
        public int? idpeople2 { get; set; }
        public short? isordered { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? iddestanation { get; set; }
        public int? idorder { get; set; }
        public int? idsizedocgroup { get; set; }
        public short? isplaned { get; set; }
        public short? isover { get; set; }
        public short? isredirect { get; set; }
        public int? idaddress { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? address { get; set; }
        public Guid guid { get; set; }
        [Unicode(false)]
        public string? contact { get; set; }
        [Unicode(false)]
        public string? phone { get; set; }
        [Unicode(false)]
        public string? speackerphone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? idpeoplecreate { get; set; }
        public int? idpeopleedit { get; set; }
        public int? iddocstate { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docoper_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio2 { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? peoplecreate_fio { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? destanation_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_name { get; set; }
        [Unicode(false)]
        public string? order_sizeifo { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? order_address { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? order_phone { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docstate_name { get; set; }
    }
}
