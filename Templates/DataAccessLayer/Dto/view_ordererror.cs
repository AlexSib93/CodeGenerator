using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_ordererror
    {
        public int idordererror { get; set; }
        public int? iderror { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        [Unicode(false)]
        public string? addinfo { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr1 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? error_code { get; set; }
        public int? error_showtype { get; set; }
        [StringLength(13)]
        [Unicode(false)]
        public string? showtype_name { get; set; }
        public bool? error_issave { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? error_name { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? errortype_name { get; set; }
        public int? error_iderrortype { get; set; }
        public byte[]? unpack_picture { get; set; }
        [Unicode(false)]
        public string? error_message1 { get; set; }
        [Unicode(false)]
        public string? error_message2 { get; set; }
        [Unicode(false)]
        public string? error_message3 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_name { get; set; }
        public int? orderitem_numpos { get; set; }
    }
}
