using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_goodkitdetail
    {
        public int idgoodkitdetail { get; set; }
        public int? idgoodkit { get; set; }
        public int? idgood { get; set; }
        public short? isconst { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? thick { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        public bool? ismain { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? good_waste { get; set; }
        public int? measure_typ { get; set; }
        public int? good_idvalut { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? goodgroup_name { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? measure_factor { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? system_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? good_color1_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? good_color2_name { get; set; }
        public int? good_idcolor1 { get; set; }
        public int? good_idcolor2 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodtype_name { get; set; }
        public int? good_idgoodtype { get; set; }
        public int? good_idgoodtype2 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodtype_name2 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodkit_name { get; set; }
        public short? goodkitgroup_isactive { get; set; }
        public short? good_idgoodgroup { get; set; }
        public short? good_ismy { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color1_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color2_name { get; set; }
    }
}
