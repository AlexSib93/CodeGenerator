using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgoodservice", Name = "idx_ordergoodservice_idgoodservice")]
    [Index("idorder", Name = "idx_ordergoodservice_idorder")]
    [Index("idorderitem", Name = "idx_ordergoodservice_idorderitem")]
    [Index("idvalut", Name = "idx_ordergoodservice_idvalut")]
    public partial class ordergoodservice
    {
        [Key]
        public int idordergoodservice { get; set; }
        public int? idorder { get; set; }
        public int? idgoodservice { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? perc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        public short? iscalc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase4 { get; set; }
        /// <summary>
        /// Дата 1(смысл на усмотрение компании)
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? date1 { get; set; }
        /// <summary>
        /// Дата 2(смысл на усмотрение компании)
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? date2 { get; set; }
        /// <summary>
        /// Дата 3(смысл на усмотрение компании)
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? date3 { get; set; }

        [ForeignKey("idgoodservice")]
        [InverseProperty("ordergoodservice")]
        public virtual goodservice? idgoodserviceNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("ordergoodservice")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("ordergoodservice")]
        public virtual orderitem? idorderitemNavigation { get; set; }
    }
}
