using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgood", Name = "idx_ordergood_idgood")]
    [Index("idorder", Name = "idx_ordergood_idorder")]
    [Index("idorderitem", Name = "idx_ordergood_idorderitem")]
    [Index("parentid", Name = "idx_ordergood_parentid")]
    [Index("width", Name = "idx_ordergood_width")]
    public partial class ordergood
    {
        public ordergood()
        {
            delivdocpos = new HashSet<delivdocpos>();
            manufactdocpos = new HashSet<manufactdocpos>();
        }

        [Key]
        public int idordergood { get; set; }
        public int? idgood { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? thick { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qustore { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase4 { get; set; }
        /// <summary>
        /// Количество в производственном задании
        /// </summary>
        public int? quinmanufact { get; set; }
        public int? quready { get; set; }
        public int? parentid { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        public int? addint { get; set; }
        public int? addint2 { get; set; }
        public int? idgoodkitdetail { get; set; }
        public int? idgoodkit { get; set; }
        public int? idorder { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("ordergood")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("ordergood")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("ordergood")]
        public virtual orderitem? idorderitemNavigation { get; set; }
        [InverseProperty("idordergoodNavigation")]
        public virtual ICollection<delivdocpos> delivdocpos { get; set; }
        [InverseProperty("idordergoodNavigation")]
        public virtual ICollection<manufactdocpos> manufactdocpos { get; set; }
    }
}
