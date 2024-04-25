using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgoodservice", Name = "idx_supplydocgoodservice_idgoodservice")]
    [Index("idsupplydoc", Name = "idx_supplydocgoodservice_idsupplydoc")]
    public partial class supplydocgoodservice
    {
        [Key]
        public int idsupplydocgoodservice { get; set; }
        public int? idsupplydoc { get; set; }
        public int? idgoodservice { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? perc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }

        [ForeignKey("idgoodservice")]
        [InverseProperty("supplydocgoodservice")]
        public virtual goodservice? idgoodserviceNavigation { get; set; }
        [ForeignKey("idsupplydoc")]
        [InverseProperty("supplydocgoodservice")]
        public virtual supplydoc? idsupplydocNavigation { get; set; }
    }
}
