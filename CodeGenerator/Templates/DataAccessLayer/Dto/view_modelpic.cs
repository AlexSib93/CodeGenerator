using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_modelpic
    {
        public int? idmodel { get; set; }
        public int idmodelpic { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public short? typ { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public byte[]? picture { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? marking { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? markingshpross { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
    }
}
