using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmanufactdoc", Name = "idx_manufactdocnopyramid_idmanufactdoc")]
    [Index("idorder", Name = "idx_manufactdocnopyramid_idorder")]
    public partial class manufactdocnopyramid
    {
        [Key]
        public int idmanufactdocnopyramid { get; set; }
        public int idmanufactdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int idorder { get; set; }

        [ForeignKey("idmanufactdoc")]
        [InverseProperty("manufactdocnopyramid")]
        public virtual manufactdoc idmanufactdocNavigation { get; set; } = null!;
        [ForeignKey("idorder")]
        [InverseProperty("manufactdocnopyramid")]
        public virtual orders idorderNavigation { get; set; } = null!;
    }
}
