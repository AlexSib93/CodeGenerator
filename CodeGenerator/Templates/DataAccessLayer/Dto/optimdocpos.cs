using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("barcode", Name = "idx_optimdocpos_barcode")]
    [Index("idgood", Name = "idx_optimdocpos_idgood")]
    [Index("idoptimdoc", Name = "idx_optimdocpos_idoptimdoc")]
    [Index("idoptimdocpic", Name = "idx_optimdocpos_idoptimdocpic")]
    [Index("idorder", Name = "idx_optimdocpos_idorder")]
    [Index("idmanufactdocpos", Name = "ind_optimdocpos_idmanufactdocpos")]
    [Index("idmodelcalc", Name = "ind_optimdocpos_idmodelcalc")]
    [Index("idorderitem", Name = "ind_optimdocpos_idorderitem")]
    public partial class optimdocpos
    {
        public optimdocpos()
        {
            optimdocsign = new HashSet<optimdocsign>();
        }

        [Key]
        public int idoptimdocpos { get; set; }
        public int? idoptimdoc { get; set; }
        public int? idgood { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? thick { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qustore { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? marking { get; set; }
        public int? numpos { get; set; }
        public int? numpos2 { get; set; }
        public int? idmodelcalc { get; set; }
        public int? idoptimdocpic { get; set; }
        /// <summary>
        /// Позиция заказа
        /// </summary>
        public int? idorderitem { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        public int? idordergood { get; set; }
        public int? cart { get; set; }
        public int? cell { get; set; }
        public int? orderitemnum { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? profilemarking { get; set; }
        public int? idgoodoptim { get; set; }
        public int? idmanufactdocpos { get; set; }
        public short? numwhip { get; set; }
        public short? numpair { get; set; }
        public short? numposbalka { get; set; }
        [StringLength(40)]
        [Unicode(false)]
        public string? barcode { get; set; }
        public int? numpos3 { get; set; }
        public int? idorder { get; set; }
        public short? isready { get; set; }
        public int? row { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("optimdocpos")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idmanufactdocpos")]
        [InverseProperty("optimdocpos")]
        public virtual manufactdocpos? idmanufactdocposNavigation { get; set; }
        [ForeignKey("idmodelcalc")]
        [InverseProperty("optimdocpos")]
        public virtual modelcalc? idmodelcalcNavigation { get; set; }
        [ForeignKey("idoptimdoc")]
        [InverseProperty("optimdocpos")]
        public virtual optimdoc? idoptimdocNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("optimdocpos")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("optimdocpos")]
        public virtual orderitem? idorderitemNavigation { get; set; }
        [InverseProperty("idorderitemNavigation")]
        public virtual ICollection<optimdocsign> optimdocsign { get; set; }
    }
}
