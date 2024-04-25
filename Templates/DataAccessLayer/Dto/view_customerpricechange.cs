using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_customerpricechange
    {
        public int idcustomerpricechange { get; set; }
        public int? idcustomer { get; set; }
        public int? idpricechange { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price1 { get; set; }
        public int? idseller { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? startdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? enddate { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? pricechange_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? pricechange_comment { get; set; }
        public short? pricechange_isperc { get; set; }
        public short? pricechange_typ { get; set; }
        public short? pricechange_fororder { get; set; }
        [StringLength(7)]
        [Unicode(false)]
        public string pricechange_typname { get; set; } = null!;
        [StringLength(11)]
        [Unicode(false)]
        public string pricechange_fororder_typ { get; set; } = null!;
        [Unicode(false)]
        public string? pricechangegroup_fullname { get; set; }
    }
}
