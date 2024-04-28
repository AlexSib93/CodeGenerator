using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_vectorpicture
    {
        public int idvectorpicture { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public byte[]? vectorpicture { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public int? x_pos { get; set; }
        public int? y_pos { get; set; }
        [Column("using")]
        public int? _using { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public byte[]? model { get; set; }
        [StringLength(26)]
        [Unicode(false)]
        public string? using_name { get; set; }
    }
}
