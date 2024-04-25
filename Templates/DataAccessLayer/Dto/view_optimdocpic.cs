using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_optimdocpic
    {
        public int idoptimdocpic { get; set; }
        public int? idoptimdoc { get; set; }
        public int? idgood { get; set; }
        public byte[]? picture { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idgoodbuffer { get; set; }
        public int? idoptimdocgoodin { get; set; }
        public int? whiplen { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        [Column("class")]
        public byte[]? _class { get; set; }
        public int? typ { get; set; }
        public int? thickost { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        public short? numpos { get; set; }
        public int? parentid { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color1_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color2_name { get; set; }
    }
}
