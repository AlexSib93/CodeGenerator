using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_pyramidfactpos
    {
        public int idpyramidfactpos { get; set; }
        public int? idpyramidfact { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? idordergood { get; set; }
        public int? idmodelcalc { get; set; }
        public int? idgood { get; set; }
        public int? idorder { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public int? thick { get; set; }
        public int? typ { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? barcode { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_name { get; set; }
        public int? orderitem_numpos { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? order_dtdoc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [StringLength(21)]
        [Unicode(false)]
        public string typ_name { get; set; } = null!;
    }
}
