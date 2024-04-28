using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idinstalldoc", Name = "idx_installdocfile_idinstalldoc")]
    public partial class installdocfile
    {
        [Key]
        public int idinstalldocfile { get; set; }
        public int? idinstalldoc { get; set; }
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

        [ForeignKey("idinstalldoc")]
        [InverseProperty("installdocfile")]
        public virtual installdoc? idinstalldocNavigation { get; set; }
    }
}
