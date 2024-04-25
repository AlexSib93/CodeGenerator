using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_installdocpos
    {
        public int idinstalldocpos { get; set; }
        public int? idinstalldoc { get; set; }
        public int? numpos { get; set; }
        public int? idgood { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? thick { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? idorderitem { get; set; }
        public int? idmodel { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? winue { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        public int? measure_typ { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? measure_factor { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_name { get; set; }
    }
}
