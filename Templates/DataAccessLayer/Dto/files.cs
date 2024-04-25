using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddocstate", Name = "idx_files_iddocstate")]
    public partial class files
    {
        [Key]
        public int idfiles { get; set; }
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
        public Guid guid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? iddocoper { get; set; }
        public int? iddocstate { get; set; }

        [ForeignKey("iddocstate")]
        [InverseProperty("files")]
        public virtual docstate? iddocstateNavigation { get; set; }
    }
}
