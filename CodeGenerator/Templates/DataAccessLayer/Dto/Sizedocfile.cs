using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idsizedoc", Name = "idx_sizedocfile_idsizedoc")]
    public partial class sizedocfile
    {
        [Key]
        public int idsizedocfile { get; set; }
        public int? idsizedoc { get; set; }
        public byte[]? filebyte { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? path { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtfile { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idsizedoc")]
        [InverseProperty("sizedocfile")]
        public virtual sizedoc? idsizedocNavigation { get; set; }
    }
}
