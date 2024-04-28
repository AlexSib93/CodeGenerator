using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class picture
    {
        [Key]
        public int idpicture { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public bool stretchvertical { get; set; }
        public bool stretchhorizontal { get; set; }
        [Column("picture")]
        public byte[]? picture1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool bevel { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? marking { get; set; }
    }
}
