using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddocscriptgroup", Name = "idx_docscript_iddocscriptgroup")]
    public partial class docscript
    {
        [Key]
        public int iddocscript { get; set; }
        [Unicode(false)]
        public string? name { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? activescript { get; set; }
        [Column(TypeName = "text")]
        public string? codescript { get; set; }
        public short? compiled { get; set; }
        public byte[]? dll { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? scriptgroup { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcompile { get; set; }
        public int? iddocscriptgroup { get; set; }
        public short? tomenu { get; set; }
        /// <summary>
        /// Переносить в дилерскую версию
        /// </summary>
        public bool? indealerbase { get; set; }
        public bool? tomainmenu { get; set; }
        public bool? tonopapermenu { get; set; }
        public byte[]? picture { get; set; }
        public byte[]? pdb { get; set; }

        [ForeignKey("iddocscriptgroup")]
        [InverseProperty("docscript")]
        public virtual docscriptgroup? iddocscriptgroupNavigation { get; set; }
    }
}
