using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_modelscript
    {
        public int idmodelscript { get; set; }
        public int? idmodelpart { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "text")]
        public string? comment { get; set; }
        public byte[]? dll { get; set; }
        public short? compiled { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? scriptgroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcompile { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "text")]
        public string? codescript { get; set; }
        public short? activescript { get; set; }
        public int? idversion { get; set; }
        public Guid guid { get; set; }
        public byte[]? pdb { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? modelpart_name { get; set; }
        public int? modelpart_numpos { get; set; }
        public short? typ { get; set; }
    }
}
