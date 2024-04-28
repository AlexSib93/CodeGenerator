using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgood", Name = "idx_supplydocpos_idgood")]
    [Index("idgood2", Name = "idx_supplydocpos_idgood2")]
    [Index("idgoodmeasure", Name = "idx_supplydocpos_idgoodmeasure")]
    [Index("idmanufactdocpos", Name = "idx_supplydocpos_idmanufactdocpos")]
    [Index("idmodel", Name = "idx_supplydocpos_idmodel")]
    [Index("idorderitem", Name = "idx_supplydocpos_idorderitem")]
    [Index("idsupplydoc", Name = "idx_supplydocpos_idsupplydoc")]
    [Index("parentid", Name = "idx_supplydocpos_parentid")]
    [Index("width", Name = "idx_supplydocpos_width")]
    public partial class supplydocpos
    {
        public supplydocpos()
        {
            Inverseparent = new HashSet<supplydocpos>();
            storedocpos = new HashSet<storedocpos>();
            supplydocsign = new HashSet<supplydocsign>();
        }

        [Key]
        public int idsupplydocpos { get; set; }
        public int? idsupplydoc { get; set; }
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
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qustore { get; set; }
        public int? parentid { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang2 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr { get; set; }
        [Column(TypeName = "numeric(20, 5)")]
        public decimal? addint { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        public int? thickness { get; set; }
        public int? idmanufactdocpos { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr3 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr4 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr5 { get; set; }
        public int? idgoodmeasure { get; set; }
        public int? idgood2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sumnds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? nds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebasends { get; set; }
        public int? orderitemnum { get; set; }

        [ForeignKey("idgood2")]
        [InverseProperty("supplydocposidgood2Navigation")]
        public virtual good? idgood2Navigation { get; set; }
        [ForeignKey("idgood")]
        [InverseProperty("supplydocposidgoodNavigation")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idgoodmeasure")]
        [InverseProperty("supplydocpos")]
        public virtual goodmeasure? idgoodmeasureNavigation { get; set; }
        [ForeignKey("idmanufactdocpos")]
        [InverseProperty("supplydocpos")]
        public virtual manufactdocpos? idmanufactdocposNavigation { get; set; }
        [ForeignKey("idmodel")]
        [InverseProperty("supplydocpos")]
        public virtual model? idmodelNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("supplydocpos")]
        public virtual orderitem? idorderitemNavigation { get; set; }
        [ForeignKey("idsupplydoc")]
        [InverseProperty("supplydocpos")]
        public virtual supplydoc? idsupplydocNavigation { get; set; }
        [ForeignKey("parentid")]
        [InverseProperty("Inverseparent")]
        public virtual supplydocpos? parent { get; set; }
        [InverseProperty("parent")]
        public virtual ICollection<supplydocpos> Inverseparent { get; set; }
        [InverseProperty("idsupplydocposNavigation")]
        public virtual ICollection<storedocpos> storedocpos { get; set; }
        [InverseProperty("idsupplydocposNavigation")]
        public virtual ICollection<supplydocsign> supplydocsign { get; set; }
    }
}
