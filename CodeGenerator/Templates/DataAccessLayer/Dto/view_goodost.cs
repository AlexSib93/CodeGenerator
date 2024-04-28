using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_goodost
    {
        public int idgoodost { get; set; }
        public int? idgood { get; set; }
        public int? idorder { get; set; }
        public int? idmanufactdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtreg { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? val { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valnew { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valold { get; set; }
        public int? idstoredepart { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? good_waste { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? system_name { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? measure_factor { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? goodgroup_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color1_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color2_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodtype_name { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? good_price1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? good_price2 { get; set; }
    }
}
