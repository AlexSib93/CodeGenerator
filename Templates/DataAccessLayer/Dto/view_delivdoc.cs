using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_delivdoc
    {
        public int iddelivdoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? iddelivdocgroup { get; set; }
        public int? idpeople { get; set; }
        public int? iddocoper { get; set; }
        public int? idcustomer { get; set; }
        public int? idpeople2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        public int? idorder { get; set; }
        public int? iddestanation { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? address { get; set; }
        public int? idaddress { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        public int? qupos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? winue { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? contact { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? phone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        public int? idcar { get; set; }
        public int? idpeopleexp { get; set; }
        public int? idpeopledrv { get; set; }
        public int? iddocstate { get; set; }
        public short? ride { get; set; }
        public int? idmanufactdoccar { get; set; }
        public int? parentid { get; set; }
        public int? idstoredepart { get; set; }
        public int? idtariff { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docoper_name { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? poeple2_fio { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? destanation_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? car_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? car_statesign { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? car_marking { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? peopleexp_name { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? peopledrv_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docstate_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? storedepart_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? tariff_name { get; set; }
    }
}
