using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgoodservice", Name = "idx_installdocgoodservice_idgoodservice")]
    [Index("idinstalldoc", Name = "idx_installdocgoodservice_idinstalldoc")]
    [Index("idinstalldocpos", Name = "idx_installdocgoodservice_idinstalldocpos")]
    [Index("idorder", Name = "idx_installdocgoodservice_idorder")]
    [Index("idorderitem", Name = "idx_installdocgoodservice_idorderitem")]
    public partial class installdocgoodservice
    {
        [Key]
        public int idinstalldocgoodservice { get; set; }
        public int? idinstalldoc { get; set; }
        public int? idinstalldocpos { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
        public int? idgoodservice { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase2 { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        public short? iscalc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idgoodservice")]
        [InverseProperty("installdocgoodservice")]
        public virtual goodservice? idgoodserviceNavigation { get; set; }
        [ForeignKey("idinstalldoc")]
        [InverseProperty("installdocgoodservice")]
        public virtual installdoc? idinstalldocNavigation { get; set; }
        [ForeignKey("idinstalldocpos")]
        [InverseProperty("installdocgoodservice")]
        public virtual installdocpos? idinstalldocposNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("installdocgoodservice")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("installdocgoodservice")]
        public virtual orderitem? idorderitemNavigation { get; set; }
    }
}
