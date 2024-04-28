using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_goodbuffer
    {
        public int idgoodbuffer { get; set; }
        public int? idgood { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? thick { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? marking { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? status { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? profilemarking { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? barcode { get; set; }
        public int? idmanufactdocin { get; set; }
        public int? idmanufactdocout { get; set; }
        public int? idoptimdocin { get; set; }
        public int? idoptimdocout { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? row { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? cell { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        public int? idstoredepart { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        [StringLength(11)]
        [Unicode(false)]
        public string status_name { get; set; } = null!;
        [StringLength(64)]
        [Unicode(false)]
        public string? color1_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color2_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? storedepart_name { get; set; }
    }
}
