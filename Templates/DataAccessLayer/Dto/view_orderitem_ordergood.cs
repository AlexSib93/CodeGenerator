using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_orderitem_ordergood
    {
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? numpos { get; set; }
        public int? idmodel { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? thick { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        [Column(TypeName = "numeric(17, 4)")]
        public decimal? sqr { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qustore { get; set; }
        public int? typ { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? measure_factor { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        [Column(TypeName = "numeric(38, 4)")]
        public decimal? pricechange_oi_nac { get; set; }
        [Column(TypeName = "numeric(38, 6)")]
        public decimal? pricechange_order_nac { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodtype_name { get; set; }
        public int? good_idgoodtype { get; set; }
    }
}
