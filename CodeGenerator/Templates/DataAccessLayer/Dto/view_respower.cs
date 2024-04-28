using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_respower
    {
        public int idrespower { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        public int? idpower { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? val { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        public int? idpeople2 { get; set; }
        public int? idorder { get; set; }
        public int? idservicedoc { get; set; }
        public int? idorderitem { get; set; }
        public int? orderitemnum { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? power_name { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio2 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? productionsite_name { get; set; }
        public int? orderitem_numpos { get; set; }
    }
}
