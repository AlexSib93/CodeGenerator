using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_goodcolorparam
    {
        public int idgoodcolorparam { get; set; }
        public int idgood { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? minost { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? waste { get; set; }
        public short? deliverytime { get; set; }
        public bool? usehouse { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? maxost { get; set; }
        public int? idcustomer { get; set; }
        [Column(TypeName = "numeric(8, 4)")]
        public decimal? rate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtpost { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? minost2 { get; set; }
        public bool replenishment { get; set; }
        public int? idgoodoptim { get; set; }
        public int? idstoragespace { get; set; }
        public int? idstoredepart { get; set; }
        public int? idcolorgroupprice { get; set; }
        public short? purchase { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? rank1 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? rank2 { get; set; }
        [StringLength(13)]
        [Unicode(false)]
        public string? replenishment_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? colorgroupprice_name { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? purchase_name { get; set; }
    }
}
