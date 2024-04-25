using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcar", Name = "idx_manufactdocorder_idcar")]
    [Index("idmanufactdoc", Name = "idx_manufactdocorder_idmanufactdoc")]
    [Index("idorder", Name = "idx_manufactdocorder_idorder")]
    public partial class manufactdocorder
    {
        [Key]
        public int idmanufactdocorder { get; set; }
        public int? idorder { get; set; }
        public int? idcar { get; set; }
        public byte? run { get; set; }
        public byte? sort { get; set; }
        public int? idmanufactdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? posgroup { get; set; }
        public int? cart { get; set; }
        public int? cell { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deliverytime { get; set; }
        public int? iddestanation { get; set; }
        public int? colorvalue { get; set; }
        public int? idroute { get; set; }
        public bool? nopyramid { get; set; }

        [ForeignKey("idcar")]
        [InverseProperty("manufactdocorder")]
        public virtual car? idcarNavigation { get; set; }
        [ForeignKey("idmanufactdoc")]
        [InverseProperty("manufactdocorder")]
        public virtual manufactdoc? idmanufactdocNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("manufactdocorder")]
        public virtual orders? idorderNavigation { get; set; }
    }
}
