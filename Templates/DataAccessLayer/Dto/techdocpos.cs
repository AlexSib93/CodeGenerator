using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgood", Name = "idx_techdocpos_idgood")]
    [Index("idmanufactdocpos", Name = "idx_techdocpos_idmanufactdocpos")]
    [Index("idmodel", Name = "idx_techdocpos_idmodel")]
    [Index("idorderitem", Name = "idx_techdocpos_idorderitem")]
    [Index("idtechdoc", Name = "idx_techdocpos_idtechdoc")]
    [Index("width", Name = "idx_techdocpos_width")]
    public partial class techdocpos
    {
        [Key]
        public int idtechdocpos { get; set; }
        public int? idtechdoc { get; set; }
        public int? numpos { get; set; }
        public int? idgood { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? thick { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? idorderitem { get; set; }
        public int? idmodel { get; set; }
        public int? idequipmentprofile { get; set; }
        public int? idordergood { get; set; }
        public int? idmodelcalc { get; set; }
        public int? addint { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? barnumpos { get; set; }
        public int? idorder { get; set; }
        public int? idmanufactdocpos { get; set; }
        public int? orderitemnum { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("techdocpos")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idmanufactdocpos")]
        [InverseProperty("techdocpos")]
        public virtual manufactdocpos? idmanufactdocposNavigation { get; set; }
        [ForeignKey("idmodel")]
        [InverseProperty("techdocpos")]
        public virtual model? idmodelNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("techdocpos")]
        public virtual orderitem? idorderitemNavigation { get; set; }
        [ForeignKey("idtechdoc")]
        [InverseProperty("techdocpos")]
        public virtual techdoc? idtechdocNavigation { get; set; }
    }
}
