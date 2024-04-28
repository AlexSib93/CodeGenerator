using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmanufactdocpos", Name = "idx_delivdocpos_idmanufactdocpos")]
    [Index("idorder", Name = "idx_delivdocpos_idorder")]
    [Index("idstoredoc", Name = "idx_delivdocpos_idstoredoc")]
    public partial class delivdocpos
    {
        [Key]
        public int iddelivdocpos { get; set; }
        public int? iddelivdoc { get; set; }
        public int? idorderitem { get; set; }
        public int? idgood { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? thick { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? winue { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        public int? idordergood { get; set; }
        public int? orderitemnum { get; set; }
        public int? idmodelcalc { get; set; }
        public int? idorder { get; set; }
        public int? idmanufactdocpos { get; set; }
        public int? idstoredoc { get; set; }

        [ForeignKey("iddelivdoc")]
        [InverseProperty("delivdocpos")]
        public virtual delivdoc? iddelivdocNavigation { get; set; }
        [ForeignKey("idgood")]
        [InverseProperty("delivdocpos")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idmanufactdocpos")]
        [InverseProperty("delivdocpos")]
        public virtual manufactdocpos? idmanufactdocposNavigation { get; set; }
        [ForeignKey("idmodelcalc")]
        [InverseProperty("delivdocpos")]
        public virtual modelcalc? idmodelcalcNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("delivdocpos")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idordergood")]
        [InverseProperty("delivdocpos")]
        public virtual ordergood? idordergoodNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("delivdocpos")]
        public virtual orderitem? idorderitemNavigation { get; set; }
        [ForeignKey("idstoredoc")]
        [InverseProperty("delivdocpos")]
        public virtual storedoc? idstoredocNavigation { get; set; }
    }
}
