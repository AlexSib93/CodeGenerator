using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("barcode", Name = "idx_manufactdocpos_barcode")]
    [Index("idgood", Name = "idx_manufactdocpos_idgood")]
    [Index("idmanufactdoc", Name = "idx_manufactdocpos_idmanufactdoc")]
    [Index("idmanufactdoc", Name = "idx_manufactdocpos_idmanufactdoc_inc")]
    [Index("idmodelcalc", Name = "idx_manufactdocpos_idmodelcalc")]
    [Index("idorderitem", Name = "idx_manufactdocpos_idorderitem")]
    [Index("idorderitem", "orderitemnum", Name = "idx_manufactdocpos_idorderitem_orderitemnum")]
    [Index("parentid", Name = "idx_manufactdocpos_parentid")]
    [Index("idordergood", Name = "ind_manufactdocpos_idordergood")]
    public partial class manufactdocpos
    {
        public manufactdocpos()
        {
            delivdocpos = new HashSet<delivdocpos>();
            manufactdocpyramid = new HashSet<manufactdocpyramid>();
            optimdocpos = new HashSet<optimdocpos>();
            productiondocpos = new HashSet<productiondocpos>();
            rotoxhouse = new HashSet<rotoxhouse>();
            storedocpos = new HashSet<storedocpos>();
            supplydocpos = new HashSet<supplydocpos>();
            techdocpos = new HashSet<techdocpos>();
        }

        [Key]
        public int idmanufactdocpos { get; set; }
        public int? idmanufactdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? numpos { get; set; }
        public int? thick { get; set; }
        public int? idorderitem { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? posgroup { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public int? idgood { get; set; }
        public int? numpyramid { get; set; }
        /// <summary>
        /// Количество изготовленных
        /// </summary>
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? quready { get; set; }
        public int? parentid { get; set; }
        /// <summary>
        /// Ссылка на материал к позиции
        /// </summary>
        public int? idordergood { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? idmodelcalc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? manufactname { get; set; }
        public int? orderitemnum { get; set; }
        public int? cart { get; set; }
        public int? cell { get; set; }
        [StringLength(40)]
        [Unicode(false)]
        public string? barcode { get; set; }
        public bool? addbit1 { get; set; }
        public bool? addbit2 { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("manufactdocpos")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idmanufactdoc")]
        [InverseProperty("manufactdocpos")]
        public virtual manufactdoc? idmanufactdocNavigation { get; set; }
        [ForeignKey("idordergood")]
        [InverseProperty("manufactdocpos")]
        public virtual ordergood? idordergoodNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("manufactdocpos")]
        public virtual orderitem? idorderitemNavigation { get; set; }
        [InverseProperty("idmanufactdocposNavigation")]
        public virtual ICollection<delivdocpos> delivdocpos { get; set; }
        [InverseProperty("idmanufactdocposNavigation")]
        public virtual ICollection<manufactdocpyramid> manufactdocpyramid { get; set; }
        [InverseProperty("idmanufactdocposNavigation")]
        public virtual ICollection<optimdocpos> optimdocpos { get; set; }
        [InverseProperty("idmanufactdocposNavigation")]
        public virtual ICollection<productiondocpos> productiondocpos { get; set; }
        [InverseProperty("idmanufactdocposNavigation")]
        public virtual ICollection<rotoxhouse> rotoxhouse { get; set; }
        [InverseProperty("idmanufactdocposNavigation")]
        public virtual ICollection<storedocpos> storedocpos { get; set; }
        [InverseProperty("idmanufactdocposNavigation")]
        public virtual ICollection<supplydocpos> supplydocpos { get; set; }
        [InverseProperty("idmanufactdocposNavigation")]
        public virtual ICollection<techdocpos> techdocpos { get; set; }
    }
}
