using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgood", Name = "idx_modelcalc_idgood")]
    [Index("idmodel", Name = "idx_modelcalc_idmodel")]
    [Index("idorder", Name = "idx_modelcalc_idorder")]
    [Index("idorderitem", Name = "idx_modelcalc_idorderitem")]
    [Index("width", Name = "idx_modelcalc_width")]
    public partial class modelcalc
    {
        public modelcalc()
        {
            delivdocpos = new HashSet<delivdocpos>();
            optimdocpos = new HashSet<optimdocpos>();
        }

        [Key]
        public int idmodelcalc { get; set; }
        public int? idgood { get; set; }
        public int? idmodel { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? thick { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public int? thickness { get; set; }
        public int? idorder { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? qustore { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? waste { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr { get; set; }
        [Column(TypeName = "numeric(20, 5)")]
        public decimal? addint { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr3 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr4 { get; set; }
        public byte[]? smcrypt { get; set; }
        public byte[]? smbasecrypt { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        public bool? addbool { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? quinmanufact { get; set; }
        public short? sourcetype { get; set; }
        public bool? isready { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? assemblyunit { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("modelcalc")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idmodel")]
        [InverseProperty("modelcalc")]
        public virtual model? idmodelNavigation { get; set; }
        [InverseProperty("idmodelcalcNavigation")]
        public virtual ICollection<delivdocpos> delivdocpos { get; set; }
        [InverseProperty("idmodelcalcNavigation")]
        public virtual ICollection<optimdocpos> optimdocpos { get; set; }
    }
}
