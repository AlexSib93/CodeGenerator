using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_model
    {
        public int idmodel { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? typ { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [Column("class")]
        public byte[]? _class { get; set; }
        public byte[]? classnative { get; set; }
    }
}
