using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_constructiontype
    {
        public int idconstructiontype { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idversion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? numpos { get; set; }
        public short? isactive { get; set; }
        public Guid guid { get; set; }
        public int? openview { get; set; }
        [StringLength(64)]
        public string? name_strkey { get; set; }
        [StringLength(7)]
        [Unicode(false)]
        public string? openview_name { get; set; }
    }
}
