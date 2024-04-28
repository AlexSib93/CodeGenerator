using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmanufactdoc", Name = "idx_manufactdocpyramidpos_idmanufactdoc")]
    [Index("idmanufactdoccar", Name = "idx_manufactdocpyramidpos_idmanufactdoccar")]
    [Index("idmanufactdocpyramid", Name = "idx_manufactdocpyramidpos_idmanufactdocpyramid")]
    [Index("idorderitem", Name = "idx_manufactdocpyramidpos_idorderitem")]
    public partial class manufactdocpyramidpos
    {
        [Key]
        public int idmanufactdocpyramidpos { get; set; }
        public int? idmanufactdoc { get; set; }
        public int? idmanufactdocpyramid { get; set; }
        public int? idmanufactdoccar { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public short? numpos { get; set; }
        public int? row { get; set; }
        public int? col { get; set; }
        public int? orderitemnum { get; set; }
        public short? orient { get; set; }
        [Required]
        public bool? active { get; set; }
        public int? side { get; set; }

        [ForeignKey("idmanufactdoc")]
        [InverseProperty("manufactdocpyramidpos")]
        public virtual manufactdoc? idmanufactdocNavigation { get; set; }
        [ForeignKey("idmanufactdoccar")]
        [InverseProperty("manufactdocpyramidpos")]
        public virtual manufactdoccar? idmanufactdoccarNavigation { get; set; }
        [ForeignKey("idmanufactdocpyramid")]
        [InverseProperty("manufactdocpyramidpos")]
        public virtual manufactdocpyramid? idmanufactdocpyram { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("manufactdocpyramidpos")]
        public virtual orderitem? idorderitemNavigation { get; set; }
    }
}
