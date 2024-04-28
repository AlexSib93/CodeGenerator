using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_pricechange
    {
        public int idpricechange { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? typ { get; set; }
        public short? fororder { get; set; }
        public short? isperc { get; set; }
        public int? idpricechangegroup { get; set; }
        public Guid guid { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? defaultvalue { get; set; }
        public bool? indealerbase { get; set; }
        public bool? visibledealer { get; set; }
        [StringLength(7)]
        [Unicode(false)]
        public string? pricechange_typ { get; set; }
        [StringLength(11)]
        [Unicode(false)]
        public string? fororder_typ { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? pricechange_group { get; set; }
        [Unicode(false)]
        public string? pricechangegroup_fullname { get; set; }
    }
}
