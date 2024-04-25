using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolor1", Name = "idx_storedocpos_idcolor1")]
    [Index("idcolor2", Name = "idx_storedocpos_idcolor2")]
    [Index("idgood", Name = "idx_storedocpos_idgood")]
    [Index("idgood2", Name = "idx_storedocpos_idgood2")]
    [Index("idgoodmeasure", Name = "idx_storedocpos_idgoodmeasure")]
    [Index("idmanufactdocpos", Name = "idx_storedocpos_idmanufactdocpos")]
    [Index("idorderitem", Name = "idx_storedocpos_idorderitem")]
    [Index("idproductiondocpos", Name = "idx_storedocpos_idproductiondocpos")]
    [Index("idstoragespace", Name = "idx_storedocpos_idstoragespace")]
    [Index("idstoredoc", Name = "idx_storedocpos_idstoredoc")]
    [Index("idsupplydocpos", Name = "idx_storedocpos_idsupplydocpos")]
    [Index("parentid", Name = "idx_storedocpos_parentid")]
    public partial class storedocpos
    {
        public storedocpos()
        {
            Inverseparent = new HashSet<storedocpos>();
            storedocsign = new HashSet<storedocsign>();
        }

        [Key]
        public int idstoredocpos { get; set; }
        public int? idstoredoc { get; set; }
        public int? idgood { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public int? thick { get; set; }
        public int? numpos { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? part { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? qustore { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? idorderitem { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? color1 { get; set; }
        public int? color2 { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        public int? idgoodmeasure { get; set; }
        public int? idmanufactdocpos { get; set; }
        public int? parentid { get; set; }
        public int? row { get; set; }
        public int? cell { get; set; }
        public int? idsupplydocpos { get; set; }
        public int? idgood2 { get; set; }
        public int? idstoragespace { get; set; }
        public int? idproductiondocpos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sumnds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? nds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebasends { get; set; }

        [ForeignKey("idcolor1")]
        [InverseProperty("storedocposidcolor1Navigation")]
        public virtual color? idcolor1Navigation { get; set; }
        [ForeignKey("idcolor2")]
        [InverseProperty("storedocposidcolor2Navigation")]
        public virtual color? idcolor2Navigation { get; set; }
        [ForeignKey("idgood2")]
        [InverseProperty("storedocposidgood2Navigation")]
        public virtual good? idgood2Navigation { get; set; }
        [ForeignKey("idgood")]
        [InverseProperty("storedocposidgoodNavigation")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idgoodmeasure")]
        [InverseProperty("storedocpos")]
        public virtual goodmeasure? idgoodmeasureNavigation { get; set; }
        [ForeignKey("idmanufactdocpos")]
        [InverseProperty("storedocpos")]
        public virtual manufactdocpos? idmanufactdocposNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("storedocpos")]
        public virtual orderitem? idorderitemNavigation { get; set; }
        [ForeignKey("idproductiondocpos")]
        [InverseProperty("storedocpos")]
        public virtual productiondocpos? idproductiondocposNavigation { get; set; }
        [ForeignKey("idstoragespace")]
        [InverseProperty("storedocpos")]
        public virtual storagespace? idstoragespaceNavigation { get; set; }
        [ForeignKey("idstoredoc")]
        [InverseProperty("storedocpos")]
        public virtual storedoc? idstoredocNavigation { get; set; }
        [ForeignKey("idsupplydocpos")]
        [InverseProperty("storedocpos")]
        public virtual supplydocpos? idsupplydocposNavigation { get; set; }
        [ForeignKey("parentid")]
        [InverseProperty("Inverseparent")]
        public virtual storedocpos? parent { get; set; }
        [InverseProperty("parent")]
        public virtual ICollection<storedocpos> Inverseparent { get; set; }
        [InverseProperty("idstoredocposNavigation")]
        public virtual ICollection<storedocsign> storedocsign { get; set; }
    }
}
