using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_car
    {
        public int idcar { get; set; }
        public int? idcarmarking { get; set; }
        public int? idpyramid { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? statesign { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool? active { get; set; }
        public int? idproductionsite { get; set; }
        public int? idtariff { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? car_marking { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? productionsite_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? tariff_name { get; set; }
    }
}
