using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_error
    {
        public int iderror { get; set; }
        public int? iderrorgroup { get; set; }
        public int? iderrortype { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? code { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? name { get; set; }
        [Unicode(false)]
        public string? message1 { get; set; }
        [Unicode(false)]
        public string? message2 { get; set; }
        [Unicode(false)]
        public string? message3 { get; set; }
        public byte[]? picture { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        public int? showtype { get; set; }
        public bool? issave { get; set; }
        [StringLength(13)]
        [Unicode(false)]
        public string showtype_name { get; set; } = null!;
        public byte[]? unpack_picture { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? errorgroup_name { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? errortype_name { get; set; }
    }
}
