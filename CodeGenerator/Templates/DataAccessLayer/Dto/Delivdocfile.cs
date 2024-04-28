using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddelivdoc", Name = "idx_delivdocfile_iddelivdoc")]
    public partial class delivdocfile
    {
        [Key]
        public int iddelivdocfile { get; set; }
        public int? iddelivdoc { get; set; }
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

        [ForeignKey("iddelivdoc")]
        [InverseProperty("delivdocfile")]
        public virtual delivdoc? iddelivdocNavigation { get; set; }
    }
}
