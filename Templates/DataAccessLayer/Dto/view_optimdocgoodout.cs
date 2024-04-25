using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_optimdocgoodout
    {
        public int idoptimdocgoodout { get; set; }
        public int? idgood { get; set; }
        public int? idgoodbuffer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? thick { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idoptimdoc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? idcolorin { get; set; }
        public int? idcolorout { get; set; }
        public int? idcolorbase { get; set; }
        public int? idoptimdocpic { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? colorout_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? colorin_name { get; set; }
    }
}
