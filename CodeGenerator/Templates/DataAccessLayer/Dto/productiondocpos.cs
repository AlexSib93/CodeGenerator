using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgood", Name = "idx_productiondocpos_idgood")]
    [Index("idmanufactdocpos", Name = "idx_productiondocpos_idmanufactdocpos")]
    [Index("idmodel", Name = "idx_productiondocpos_idmodel")]
    [Index("idorderitem", Name = "idx_productiondocpos_idorderitem")]
    [Index("idproductiondoc", Name = "idx_productiondocpos_idproductiondoc")]
    [Index("idstoredoc", Name = "idx_productiondocpos_idstoredoc")]
    public partial class productiondocpos
    {
        public productiondocpos()
        {
            storedocpos = new HashSet<storedocpos>();
        }

        [Key]
        public int idproductiondocpos { get; set; }
        public int? idproductiondoc { get; set; }
        public int? idorderitem { get; set; }
        public int? idmodel { get; set; }
        public int? qu { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? numpos { get; set; }
        public int? idgood { get; set; }
        public int? idpeopleedit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? idordergood { get; set; }
        public int? idmodelcalc { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? barnumpos { get; set; }
        public int? idmanufactdocpos { get; set; }
        public int? idstoredoc { get; set; }

        [ForeignKey("idmanufactdocpos")]
        [InverseProperty("productiondocpos")]
        public virtual manufactdocpos? idmanufactdocposNavigation { get; set; }
        [ForeignKey("idmodel")]
        [InverseProperty("productiondocpos")]
        public virtual model? idmodelNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("productiondocpos")]
        public virtual orderitem? idorderitemNavigation { get; set; }
        [ForeignKey("idproductiondoc")]
        [InverseProperty("productiondocpos")]
        public virtual productiondoc? idproductiondocNavigation { get; set; }
        [ForeignKey("idstoredoc")]
        [InverseProperty("productiondocpos")]
        public virtual storedoc? idstoredocNavigation { get; set; }
        [InverseProperty("idproductiondocposNavigation")]
        public virtual ICollection<storedocpos> storedocpos { get; set; }
    }
}
