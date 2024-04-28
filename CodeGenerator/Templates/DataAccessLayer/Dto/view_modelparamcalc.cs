using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_modelparamcalc
    {
        public int idmodelparamcalc { get; set; }
        public int? idmodelparam { get; set; }
        public int? idmodelpart { get; set; }
        public int? idmodel { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue2 { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue2 { get; set; }
        public bool? visible { get; set; }
        public int? idmodelparamvalue { get; set; }
        public int? idmodelparamvalue2 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        public int? id { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? modelparam_name { get; set; }
        public int? orderitem_numpos { get; set; }
    }
}
