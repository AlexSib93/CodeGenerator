using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_report
    {
        public int idreport { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? reportgroup { get; set; }
        public byte[]? dll { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? filename { get; set; }
        public byte[]? report { get; set; }
        public short? loadtype { get; set; }
        public int? numpos { get; set; }
        public int? idreportgroup { get; set; }
        public short? isactive { get; set; }
        public int? idreportscript { get; set; }
        public bool? indealerbase { get; set; }
        public Guid guid { get; set; }
        public bool tomenu { get; set; }
        public byte[]? picture { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? reportgroup_name { get; set; }
        public byte[]? reportscript_dll { get; set; }
        public short? reportscript_activescript { get; set; }
        public short? reportscript_compiled { get; set; }
    }
}
